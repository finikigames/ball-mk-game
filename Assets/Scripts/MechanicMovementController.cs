using System;
using Extensions;
using UnityEngine;

public class MechanicMovementController : MonoBehaviour {
    public float Speed;
    private Camera _camera;

    private Rigidbody _rigidbody;
    
    private void Start() {
        _camera = Camera.main;

        if (!gameObject.HasComponent<Rigidbody>(out var rb)) {
            _rigidbody = gameObject.AddComponent<Rigidbody>();
        }
        else {
            _rigidbody = rb;
        }
    }

    void Update() {
        var inputVertical = Input.GetAxis("Vertical") * Speed;
        var inputHorizontal = Input.GetAxis("Horizontal") * Speed;

        if (Mathf.Abs(inputHorizontal) > 0.01f || Mathf.Abs(inputVertical) > 0.01f) {
            var cameraTransform = _camera.transform;
            var newPosition = cameraTransform.forward * inputVertical+ cameraTransform.right * inputHorizontal;
            var newPositionWithoutY = new Vector3(newPosition.x, 0f, newPosition.z);
            _rigidbody.MovePosition(newPositionWithoutY);
        }
    }
}
