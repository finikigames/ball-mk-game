using Extensions;
using Services;
using UnityEngine;

public class BallMovementPhysicsVelocity : MonoBehaviour {
    private Rigidbody _characterController;
    
    private void Start() {
        _characterController = gameObject.AddComponentLazy<Rigidbody>();
        gameObject.AddComponentLazy<SphereCollider>();
    }

    void FixedUpdate() {
        if (!BallStateService.Instance.OnGround) return;
        
        var input = InputService.Instance.InputVectorClamped;
        if (input == Vector2.zero) return;
        
        Vector3 targetDirection = new Vector3(input.x, 0f, input.y);

        _characterController.velocity = targetDirection * Time.deltaTime * BallStateService.Instance.Speed;
    }
}
