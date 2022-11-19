using Extensions;
using Scriptable;
using Services;
using UnityEngine;

public abstract class WaterFloating : MonoBehaviour {
    private float _waterLevel = 1.5f;
    private float _floatHeight = 1f;
    private Vector3 _buoyancyCenterOffset;
    private float _bounceDamp;

    private float _speedDownPercent = 0.7f;
    private float _jumpDownPercent = 0.9f;

    private BallStateService _stateService;
    private WaterSettings _waterSettings;
    private bool _onWater;
    protected Rigidbody _rigidbody;

    private float _speedDown;
    private float _jumpDown;
    private bool _isDrownDown;

    private void Start() {
        _rigidbody = gameObject.AddComponentLazy<Rigidbody>();
        _stateService = BallStateService.Instance;
        _waterSettings = _stateService.WaterSettings;
        
        SetValues();
    }

    private void FixedUpdate() {
        if (!_onWater) return;

        var actionPoint = transform.position + transform.TransformDirection(_buoyancyCenterOffset);
        var forceFactor = 1f - ((actionPoint.y - _waterLevel) / _floatHeight);


        if (!(forceFactor > 0f)) return;
        var upLift = -Physics.gravity * (forceFactor - _rigidbody.velocity.y * _bounceDamp);

        ApplyForce(upLift, actionPoint);
    }

    protected abstract void ApplyForce(Vector3 upLift, Vector3 actionPoint);

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer != LayerMask.NameToLayer("Water") ||
            _onWater) return;
        
        _onWater = true;

        _speedDown = _stateService.Speed * _speedDownPercent;
        _stateService.Speed -= _speedDown;

        _jumpDown = _stateService.JumpPower * _jumpDownPercent;
        _stateService.JumpPower -= _jumpDown;
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.layer != LayerMask.NameToLayer("Water") ||
            !_onWater) return;
        
        _onWater = false;

        _stateService.Speed += _speedDown;
        _stateService.JumpPower += _jumpDown;
    }

    private void SetValues() {
        _waterLevel = _waterSettings.WaterLevel;
        _floatHeight = _waterSettings.FloatHeight;
        _buoyancyCenterOffset = _waterSettings.BuoyancyCenterOffset;
        _bounceDamp = _waterSettings.BounceDamp;
        _speedDownPercent = _waterSettings.SpeedDownPercent;
        _jumpDownPercent = _waterSettings.JumpDownPercent;
    }

    private void OnDisable() {
        if (!_onWater) return;
        
        _stateService.Speed += _speedDown;
        _stateService.JumpPower += _jumpDown;
    }
}
