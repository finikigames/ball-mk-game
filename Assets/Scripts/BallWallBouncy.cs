using Extensions;
using Services;
using UnityEngine;

namespace DefaultNamespace {
    
    public class BallWallBouncy : MonoBehaviour {
        private Collider _collider;

        private void Start() {
            _collider = gameObject.AddComponentLazy<Collider>();
            _collider.material = BallStateService.Instance.BouncySettings.BouncyMaterial;
        }

        private void OnDestroy() {
            _collider.material = null;
        }
    }
}