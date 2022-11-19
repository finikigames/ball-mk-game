using Extensions;
using Scriptable;
using Services;
using UnityEngine;

public class BallDoubleJump : MonoBehaviour {
    private Rigidbody _rigidbody;
    private float _jumpDown;
    private float _jumpPowerPercent;
    private bool _isSecondJump;
    private bool _canJump;

    private JumpSettings _jumpSettings;
    private BallStateService _stateService;

    private void Start() {
        _rigidbody = gameObject.AddComponentLazy<Rigidbody>();
        _stateService = BallStateService.Instance;
        _jumpSettings = _stateService.JumpSettings;

        SetValues();
    }

    private void FixedUpdate() {
        SecondJump(InputService.Instance.Jump.Value, InputService.Instance.IsJumped);
        CheckGround();
    }

    private void SecondJump(bool jump, bool isJumpComplete) {
        if (_stateService.OnGround || _isSecondJump) return;
        if (jump && !isJumpComplete && !_canJump) return;
        _canJump = true;
        if (_stateService.OnGround || !jump) return;
  
        _isSecondJump = true;
        _canJump = false;
        _rigidbody.AddForce(Vector3.up * _stateService.JumpPower, ForceMode.Impulse);
    }

    private void CheckGround() {
        if (!_stateService.OnGround) return;

        _isSecondJump = false;
    }

    private void SetValues() {
        _jumpPowerPercent = _jumpSettings.DoubleJumpPower;
        _jumpDown = _stateService.JumpPower * _jumpPowerPercent;
        _stateService.JumpPower -= _jumpDown;
    }

    private void OnDisable() {
        _stateService.JumpPower += _jumpDown;
    }
}