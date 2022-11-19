using Extensions;
using UnityEngine;

namespace DefaultNamespace {
    public enum ColliderType {
        Sphere,
        Box,
        Mesh
    }
    
    public class BallBoxCollider : MonoBehaviour {
        private MeshFilter _meshRenderer;
        private Mesh _oldMesh;

        private ColliderType _type;
        
        private void Start() {
            _meshRenderer = gameObject.AddComponentLazy<MeshFilter>();
            _oldMesh = _meshRenderer.mesh;
            _meshRenderer.mesh = Resources.GetBuiltinResource<Mesh>("Cube.fbx");
            var collider = GetColliderType();
            Destroy(collider);
            gameObject.AddComponentLazy<BoxCollider>();
        }

        private Collider GetColliderType() {
            var collider = gameObject.AddComponentLazy<Collider>();

            if (collider.GetType() == typeof(MeshCollider)) {
                _type = ColliderType.Mesh;
            }

            if (collider.GetType() == typeof(BoxCollider)) {
                _type = ColliderType.Box;
            }

            if (collider.GetType() == typeof(SphereCollider)) {
                _type = ColliderType.Sphere;
            }

            return collider;
        }

        private void ApplyOldCollider() {
            var collider = gameObject.AddComponentLazy<Collider>();
            Destroy(collider);
            
            if (_type == ColliderType.Mesh) {
                gameObject.AddComponentLazy<MeshCollider>();
            }

            if (_type == ColliderType.Box) {
                gameObject.AddComponentLazy<BoxCollider>();
            }

            if (_type == ColliderType.Sphere) {
                gameObject.AddComponentLazy<SphereCollider>();
            }
        }

        private void OnDisable() {
            _meshRenderer.mesh = _oldMesh;
            ApplyOldCollider();
        }
    }
}