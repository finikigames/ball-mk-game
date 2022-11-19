public class BallUpScale : BallScale {
    protected override void SetValues() {
        base.SetValues();
        _scaleLimit = _settings.ScaleUpLimit;
        _scaleSpeed = (_scaleLimit.x - _defaultScale.x) / _scaleTime / ApplicationService.Instance.ApplicationFrameRate;
    }

    protected override void ScaleProcess() {
        if (transform.localScale.Equals(_scaleLimit)) return;
        
        if (transform.localScale.magnitude > _scaleLimit.magnitude) {
            transform.localScale = _scaleLimit;
            return;
        }

        var scale = transform.localScale;
        scale.x += _scaleSpeed;
        scale.y += _scaleSpeed;
        scale.z += _scaleSpeed;
        
        transform.localScale = scale;
    }

    protected override void RestoreScaleProcess() {
        if (transform.localScale.Equals(_defaultScale)) return;

        if (transform.localScale.magnitude < _defaultScale.magnitude) {
            transform.localScale = _defaultScale;
            return;
        }
        
        var scale = transform.localScale;
        scale.x -= _scaleSpeed;
        scale.y -= _scaleSpeed;
        scale.z -= _scaleSpeed;
        
        transform.localScale = scale;
    }
}