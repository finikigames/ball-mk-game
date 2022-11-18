using UnityEngine;

namespace Services.Base {
    public abstract class SceneSingleton<T> : MonoBehaviour where T : SceneSingleton<T> {
        protected static T instance;
        
        public static T Instance => instance;

        private void Awake() {
            instance = (T)this;
        }

        protected virtual void Initialize() {}
    }
}