using Services.Platform.Base;
using UnityEngine;

namespace Services.Platform {
    public class DesktopInput : BaseInput {
        public override bool GetJumpState() {
            return Input.GetKey(KeyCode.Space);
        }

        public override Vector2 GetInputState() {
            var inputVertical = UnityEngine.Input.GetAxis("Vertical");
            var inputHorizontal = UnityEngine.Input.GetAxis("Horizontal");
            
            return new Vector2(inputHorizontal, inputVertical);
        }
    }
}