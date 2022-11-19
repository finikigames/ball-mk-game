using UnityEngine;

public class WaterDownFloat : WaterFloating {
    protected override void ApplyForce(Vector3 upLift, Vector3 actionPoint) {
        _rigidbody.AddForceAtPosition(-upLift, actionPoint);
    }
}