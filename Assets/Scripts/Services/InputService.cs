using Extensions;
using Services.Base;
using UnityEngine;

namespace Services {
    public class InputService : BaseSingleton<InputService> {
        public Observable<Vector2> Input;
        public Observable<bool> Jump;
        public bool JumpValue;
        public Vector2 InputVector;
        public Vector2 InputVectorClamped;

        protected override void Initialize() {
            Input = new Observable<Vector2>();
            Jump = new Observable<bool>();
        }

        private void Update() {
            var inputVertical = UnityEngine.Input.GetAxis("Vertical");
            var inputHorizontal = UnityEngine.Input.GetAxis("Horizontal");
            
            var vector = new Vector2(inputHorizontal, inputVertical);
            InputVector = vector;
            Input.Value = vector;

            var throttleValue = BallStateService.Instance.InputThrottleValue;
            
            InputVectorClamped = Vector2.zero;
            
            if (Mathf.Abs(inputHorizontal) > throttleValue) {
                InputVectorClamped = new Vector2(inputHorizontal, InputVectorClamped.y);
            }
            if (Mathf.Abs(inputVertical) > throttleValue) {
                InputVectorClamped = new Vector2(InputVectorClamped.x, inputVertical);
            }

            var jump = UnityEngine.Input.GetKey(KeyCode.Space);
            Jump.Value = jump;
            JumpValue = jump;
        }
    }
}