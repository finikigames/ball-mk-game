using UnityEngine;

namespace Services.Base {
    public abstract class BaseSingleton<T> : MonoBehaviour where T : BaseSingleton<T> {
        protected static T instance;
        
        public static T Instance {
            get {
                if (instance == null) {
                    var gameObject = new GameObject(typeof(T).Name);
                    var service = gameObject.AddComponent<T>();
                    service.Initialize();
                    instance = service;
                }

                return instance;
            }
        }

        protected virtual void Initialize() {}
    }
}