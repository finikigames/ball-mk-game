using UnityEngine;

public class BallWaterUpFloat : BallWaterFloating {
    protected override void ApplyForce(Vector3 upLift, Vector3 actionPoint) {
        _rigidbody.AddForceAtPosition(upLift, actionPoint);
    }
}