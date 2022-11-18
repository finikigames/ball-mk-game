using Services;
using UnityEngine;

namespace DefaultNamespace {
    public class BallMovementInverse : MonoBehaviour {
        public void Update() {
            var input = InputService.Instance.Input.Value;
            var inversedInput = new Vector2(-input.x, -input.y);
            InputService.Instance.Input.Value = inversedInput;
            InputService.Instance.InputVector = inversedInput;

            var inputClamped = InputService.Instance.InputVectorClamped;
            var inputClampedInverse = new Vector2(-inputClamped.x, -inputClamped.y);
            InputService.Instance.InputVectorClamped = inputClampedInverse;
        }
    }
}