using Scriptable;
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

        [HideInInspector]
        public GameObject Ball;

        public BouncySettings BouncySettings;
        public BoxSettings BoxSettings;
        public TetraSettings TetraSettings;
        public ScaleSettings ScaleSettings;
        public WaterSettings WaterSettings;
        public JumpSettings JumpSettings;
        public SphereSettings SphereSettings;

        private float _currentRayLength;
        private const string _waterLayerName = "Water";

        public void InitializeBall(GameObject ball) {
            Ball = ball;
        }

        private void FixedUpdate() {
            CalculateGroundRay();
            CheckOnGround();
        }

        private void CalculateGroundRay() {
            _currentRayLength = GroundRayLength * Ball.transform.localScale.x;
        }

        private void CheckOnGround() {
            OnGround = Physics.Raycast(Ball.transform.position, -Vector3.up, _currentRayLength, ~LayerMask.NameToLayer(_waterLayerName));
        }
    }
}