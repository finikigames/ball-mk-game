using Extensions;
using Services;
using UnityEngine;

public class BallMovementPhysics : MonoBehaviour {
    [SerializeField] private bool m_UseTorque = true;
    [SerializeField] private float m_MaxAngularVelocity = 25;
    
    private Rigidbody m_Rigidbody;

    private Vector3 _input;
    
    private void Start() {
        m_Rigidbody = gameObject.AddComponentLazy<Rigidbody>();
        gameObject.AddComponentLazy<SphereCollider>();
        // Set the maximum angular velocity.
        m_Rigidbody.maxAngularVelocity = m_MaxAngularVelocity;
        m_Rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
    }
    
    private void FixedUpdate() {
        var input = InputService.Instance.InputVector;

        var movement = new Vector3(input.x, 0, input.y);
        Move(movement);
    }

    public void Move(Vector3 moveDirection) {
        if (!BallStateService.Instance.OnGround) return;
        
        var mMovePower = BallStateService.Instance.Speed;
        // If using torque to rotate the ball...
        if (m_UseTorque) {
            // ... add torque around the axis defined by the move direction.
            m_Rigidbody.AddTorque(new Vector3(moveDirection.z, 0, -moveDirection.x)*mMovePower);
        }
        else {
            // Otherwise add force in the move direction.
            m_Rigidbody.AddForce(moveDirection*mMovePower);
        }
    }
}