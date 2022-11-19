using DefaultNamespace;
using UnityEngine;

namespace Extensions {
    public static class MonoBehaviourExtensions {
        public static bool HasComponent<T>(this GameObject mb) where T : Component {
            var component = mb.GetComponent<T>();
            return component != null;
        }

        public static bool HasComponent<T>(this GameObject mb, out T component) where T : Component {
            component = mb.GetComponent<T>();
            return component != null;
        }

        public static T AddComponentLazy<T>(this GameObject gameObject) where T : Component {
            if (!gameObject.HasComponent<T>(out var component)) {
                return gameObject.AddComponent<T>();
            }

            return component;
        }
        
        public static void DelComponent<T>(this GameObject gameObject) where T : Component {
            if (gameObject.HasComponent<T>(out var component)) {
                Object.Destroy(component);
            }
        }

        public static ColliderType GetColliderType(this GameObject gameObject) {
            var collider = gameObject.GetComponent<Collider>();
            
            if (collider.GetType() == typeof(MeshCollider)) {
                return ColliderType.Mesh;
            }

            if (collider.GetType() == typeof(BoxCollider)) {
                return ColliderType.Box;
            }

            return ColliderType.Sphere;
        }
        
        public static void AddColliderByType(this GameObject gameObject, ColliderType type) {
            if (type == ColliderType.Mesh) {
                gameObject.AddComponentLazy<MeshCollider>();
            }

            if (type == ColliderType.Box) {
                gameObject.AddComponentLazy<BoxCollider>();
            }

            if (type == ColliderType.Sphere) {
                gameObject.AddComponentLazy<SphereCollider>();
            }
        }
    }
}