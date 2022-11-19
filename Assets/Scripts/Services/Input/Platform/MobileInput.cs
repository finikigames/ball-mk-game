using Services.Platform.Base;
using UnityEngine;

namespace Services.Platform {
    public class MobileInput : BaseInput {
        private Vector2 _inputJoystick;
        
        public override void Initialize() {
            var inputSettings = ApplicationService.Instance.InputSettings;

            var inputProvider = Object.Instantiate(inputSettings.InputPrefab);
            inputProvider.Joystick.JoystickCallback.AddListener(value => {
                _inputJoystick = value;
            });
        }

        public override bool GetJumpState() {
            return false;
        }
        
        public override bool GetJumpEndState() {
            return false;
        }

        public override Vector2 GetInputState() {
            return _inputJoystick;
        }
    }
}