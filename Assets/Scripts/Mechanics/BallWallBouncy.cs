using Extensions;
using Services;
using UnityEngine;

namespace DefaultNamespace {
    
    public class BallWallBouncy : MonoBehaviour {
        private Collider _collider;
        private PhysicMaterial _oldMaterial;

        private void Start() {
            _collider = gameObject.AddComponentLazy<Collider>();
            _oldMaterial = _collider.material;
            _collider.material = BallStateService.Instance.BouncySettings.BouncyMaterial;
        }

        private void OnDisable() {
            _collider.material = _oldMaterial;
        }
    }
}