using Extensions;
using Scriptable;
using Services;
using UnityEngine;

public abstract class BallScale : MonoBehaviour {
    protected Vector3 _scaleLimit;
    protected float _scaleTime;
    protected float _scaleSpeed;
    protected float _speedRestore;

    protected Rigidbody _rigidbody;
    protected Vector3 _defaultScale;
    protected ScaleSettings _settings;
    
    public void Start() {
        Initialize();
    }

    private void Initialize() {
        _rigidbody = gameObject.AddComponentLazy<Rigidbody>();
        _defaultScale = transform.localScale;
        _settings = BallStateService.Instance.ScaleSettings;
        
        SetValues();
    }

    protected virtual void SetValues() {
        _scaleTime = _settings.ScaleTime;
        _speedRestore = _settings.SpeedRestore;
    }

    private void FixedUpdate() {
        if (_rigidbody.velocity.magnitude > _speedRestore) {
            ScaleProcess();
            return;
        }
        
        RestoreScaleProcess();
    }

    protected abstract void ScaleProcess();

    protected abstract void RestoreScaleProcess();

    private void OnDisable() {
        transform.localScale = _defaultScale;
    }
}