using Extensions;
using Services.Base;
using Services.Platform;
using Services.Platform.Base;
using UnityEngine;

namespace Services {
    public class InputService : BaseSingleton<InputService> {
        public Observable<Vector2> Input;
        public Observable<bool> Jump;
        public bool IsJumped;
        public bool JumpValue;
        public Vector2 InputVector;
        public Vector2 InputVectorClamped;

        private BaseInput _input;
        
        protected override void Initialize() {
            Input = new Observable<Vector2>();
            Jump = new Observable<bool>();

            if (CheckMobileService.Instance.CheckIfMobile()) {
                _input = new MobileInput();
            }
            else {
                _input = new DesktopInput();
            }
            _input.Initialize();
         
        }

        private void Update() {
            var vector = _input.GetInputState();
            
            InputVector = vector;
            Input.Value = vector;

            var throttleValue = BallStateService.Instance.InputThrottleValue;
            
            InputVectorClamped = Vector2.zero;
            
            if (Mathf.Abs(vector.x) > throttleValue) {
                InputVectorClamped = new Vector2(vector.x, InputVectorClamped.y);
            }
            if (Mathf.Abs(vector.y) > throttleValue) {
                InputVectorClamped = new Vector2(InputVectorClamped.x, vector.y);
            }

            var jump = _input.GetJumpState();
            IsJumped = _input.GetJumpEndState();
            Jump.Value = jump;
            JumpValue = jump;
        }
    }
}