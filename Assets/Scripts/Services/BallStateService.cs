using Services.Base;
using Unity.Collections;
using UnityEngine;

namespace Services {
    public class BallStateService : SceneSingleton<BallStateService> {
        public float Speed;
        public float JumpPower;
        public float GroundRayLength;

        public float InputThrottleValue;
        [ReadOnly]
        public bool OnGround;

        private GameObject _ball;

        public BouncySettings BouncySettings;
        public BoxSettings BoxSettings;
        
        public void InitializeBall(GameObject ball) {
            _ball = ball;
        }

        private void FixedUpdate() {
            CheckOnGround();
        }

        private void CheckOnGround() {
            OnGround = Physics.Raycast(_ball.transform.position, -Vector3.up, GroundRayLength);
        }
    }
}