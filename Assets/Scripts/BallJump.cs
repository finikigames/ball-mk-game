using Extensions;
using Services;
using UnityEngine;

namespace DefaultNamespace {
    public class BallJump : MonoBehaviour {
        [SerializeField] private float m_MaxAngularVelocity = 25;
        private Rigidbody _mRigidbody;
        
        private void Start() {
            _mRigidbody = gameObject.AddComponentLazy<Rigidbody>();
            gameObject.AddComponentLazy<SphereCollider>();
            // Set the maximum angular velocity.
            _mRigidbody.maxAngularVelocity = m_MaxAngularVelocity;
            _mRigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        }
        
        private void FixedUpdate() {
            Jump(InputService.Instance.Jump.Value);
        }
        
        public void Jump(bool jump) {
            // If on the ground and jump is pressed...
            if (BallStateService.Instance.OnGround && jump) {
                // ... add force in upwards.
                _mRigidbody.AddForce(Vector3.up*BallStateService.Instance.JumpPower, ForceMode.Impulse);
            }
        }
    }
}