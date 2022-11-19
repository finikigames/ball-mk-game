using Extensions;
using Services;
using UnityEngine;

namespace DefaultNamespace {
    public class BallSphereCollider : MonoBehaviour {
        private MeshFilter _meshRenderer;
        private Mesh _oldMesh;

        private ColliderType _type;
        
        private void Start() {
            _meshRenderer = gameObject.AddComponentLazy<MeshFilter>();
            _oldMesh = _meshRenderer.mesh;
            var sphereSettings = BallStateService.Instance.SphereSettings;
            _meshRenderer.mesh = sphereSettings.SphereMesh;
            _type = gameObject.GetColliderType();
            
            gameObject.DelComponent<Collider>();
            gameObject.AddComponentLazy<SphereCollider>();
        }

        private void OnDisable() {
            _meshRenderer.mesh = _oldMesh;
            gameObject.DelComponent<Collider>();
            gameObject.AddColliderByType(_type);
        }
    }
}