using UnityEngine;

namespace Extensions {
    public static class MonoBehaviourExtensions {
        public static bool HasComponent<T>(this GameObject mb) where T : Component {
            var component = mb.GetComponent<T>();
            return component != null;
        }
        
        public static bool HasComponent<T>(this GameObject mb,  out T component) where T : Component {
            component = mb.GetComponent<T>();
            return component != null;
        }
    }
}