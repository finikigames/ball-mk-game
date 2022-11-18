using Extensions;
using Services;
using UnityEngine;

namespace DefaultNamespace {
    public class BallJump : MonoBehaviour {
        [SerializeField] private float m_MaxAngularVelocity = 25; 
        [SerializeField] private float m_JumpPower = 2; // The force added to the ball when it jumps.
        
        private const float k_GroundRayLength = 1f;
        private Rigidbody m_Rigidbody;
        
        private void Start() {
            m_Rigidbody = gameObject.AddComponentLazy<Rigidbody>();
            gameObject.AddComponentLazy<SphereCollider>();
            // Set the maximum angular velocity.
            m_Rigidbody.maxAngularVelocity = m_MaxAngularVelocity;
            m_Rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        }
        
        private void FixedUpdate() {
            Jump(InputService.Instance.Jump.Value);
        }
        
        public void Jump(bool jump) {
            // If on the ground and jump is pressed...
            if (Physics.Raycast(transform.position, -Vector3.up, k_GroundRayLength) && jump) {
                // ... add force in upwards.
                m_Rigidbody.AddForce(Vector3.up*m_JumpPower, ForceMode.Impulse);
            }
        }
    }
}