using Extensions;
using UnityEngine;

public class MechanicMovementController : MonoBehaviour {
    public float Speed;
    private Camera _camera;

    private Rigidbody _characterController;
    
    private void Start() {
        _camera = Camera.main;

        _characterController = gameObject.AddComponentLazy<Rigidbody>();
        gameObject.AddComponentLazy<SphereCollider>();
    }

    void FixedUpdate() {
        var inputVertical = Input.GetAxis("Vertical") * Speed;
        var inputHorizontal = Input.GetAxis("Horizontal") * Speed;

        if (Mathf.Abs(inputHorizontal) > 0.01f || Mathf.Abs(inputVertical) > 0.01f) {
            Vector3 targetDirection = new Vector3(inputHorizontal, 0f, inputVertical);
            //targetDirection = _camera.transform.TransformDirection(targetDirection);
            targetDirection.y = 0.0f;
            _characterController.velocity = targetDirection * Time.deltaTime * Speed;
        }
    }
}
