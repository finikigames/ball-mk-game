using UnityEngine;

namespace Services {
    // This mono behaviour on ball game object at game start
    public class BallEntryPoint : MonoBehaviour {
        private void Start() {
            BallStateService.Instance.InitializeBall(gameObject);
        }
    }
}