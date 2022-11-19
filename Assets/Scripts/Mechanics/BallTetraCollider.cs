using Extensions;
using Services;
using UnityEngine;

namespace DefaultNamespace {
    public class BallTetraCollider : MonoBehaviour {
        private MeshFilter _meshRenderer;
        private Mesh _oldMesh;

        private ColliderType _type;
        
        private void Start() {
            _meshRenderer = gameObject.AddComponentLazy<MeshFilter>();
            _oldMesh = _meshRenderer.mesh;

            var tetraSettings = BallStateService.Instance.TetraSettings;
            _meshRenderer.mesh = tetraSettings.TetraMesh;
            _type = gameObject.GetColliderType();
            
            gameObject.DelComponent<Collider>();
            var meshCollider = gameObject.AddComponentLazy<MeshCollider>();
            meshCollider.convex = true;
        }

        private void OnDisable() {
            _meshRenderer.mesh = _oldMesh;
            gameObject.DelComponent<Collider>();
            gameObject.AddColliderByType(_type);
        }
    }
}