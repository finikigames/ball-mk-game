using UnityEngine;

public class BallWaterDownFloat : BallWaterFloating {
    protected override void ApplyForce(Vector3 upLift, Vector3 actionPoint) {
        _rigidbody.AddForceAtPosition(-upLift, actionPoint);
    }
}