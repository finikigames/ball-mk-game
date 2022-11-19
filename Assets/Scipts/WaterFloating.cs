using System;
using Extensions;
using Services;
using UnityEngine;

public class WaterFloating : MonoBehaviour {
    public float WaterLevel = 1.5f;
    public float FloatHeight = 1f;
    public Vector3 BuoyancyCenterOffset;
    public float BounceDamp;

    public bool Inverse;

    public float _speedDownPercent = 0.7f;
    public float _justDownPercent = 0.9f;

    private BallStateService _stateService;
    private bool _onWater;
    private Rigidbody _rigidbody;

    private float _speedDown;
    private float _jumpDown;
    private bool _isDrownDown;

    private void Start() {
        _rigidbody = gameObject.AddComponentLazy<Rigidbody>();
        _stateService = BallStateService.Instance;
    }

    private void FixedUpdate() {
        if (!_onWater) return;

        var actionPoint = transform.position + transform.TransformDirection(BuoyancyCenterOffset);
        var forceFactor = 1f - ((actionPoint.y - WaterLevel) / FloatHeight);


        if (!(forceFactor > 0f)) return;

        var upLift = -Physics.gravity * (forceFactor - _rigidbody.velocity.y * BounceDamp);
        if (Inverse) {

            upLift = -upLift;
        }

        _rigidbody.AddForceAtPosition(upLift, actionPoint);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer != LayerMask.NameToLayer("Water")) return;

        _onWater = true;

        if (!Inverse || _isDrownDown) return;

        _speedDown = _stateService.Speed * _speedDownPercent;
        _stateService.Speed -= _speedDown;

        _jumpDown = _stateService.JumpPower * _justDownPercent;
        _stateService.JumpPower -= _jumpDown;
        
        _isDrownDown = true;
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.layer != LayerMask.NameToLayer("Water")) return;

        _onWater = false;

        if (!Inverse || !_isDrownDown) return;

        _stateService.Speed += _speedDown;
        _stateService.JumpPower += _jumpDown;

        _isDrownDown = false;
    }
}
