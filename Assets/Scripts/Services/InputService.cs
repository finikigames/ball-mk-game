using System;
using Extensions;
using UnityEngine;

namespace Services {
    public class InputService : MonoBehaviour {
        public Observable<Vector2> Input;
        public Observable<bool> Jump;
        public Vector2 InputVector;

        private static InputService _instance;

        public static InputService Instance {
            get {
                if (_instance == null) {
                    var gameObject = new GameObject("Input Service");
                    var inputService = gameObject.AddComponent<InputService>();
                    inputService.Initialize();
                    _instance = inputService;
                }

                return _instance;
            }
        }

        public void Initialize() {
            Input = new Observable<Vector2>();
            Jump = new Observable<bool>();
        }

        private void Update() {
            var inputVertical = UnityEngine.Input.GetAxis("Vertical");
            var inputHorizontal = UnityEngine.Input.GetAxis("Horizontal");

            if (Mathf.Abs(inputHorizontal) > 0.01f || Mathf.Abs(inputVertical) > 0.01f) {
                var vector = new Vector2(inputHorizontal, inputVertical);
                InputVector = vector;
                Input.Value = vector;
            }

            Jump.Value = UnityEngine.Input.GetKeyDown(KeyCode.Space);
        }
    }
}