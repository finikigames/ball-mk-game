using Scriptable;
using Services.Base;
﻿using DefaultNamespace;
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

        public GameObject Ball;

        public BouncySettings BouncySettings;
        public BoxSettings BoxSettings;
        public TetraSettings TetraSettings;
        public ScaleSettings ScaleSettings;
        public WaterSettings WaterSettings;

        private float _currentRayLength;
        
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
            OnGround = Physics.Raycast(Ball.transform.position, -Vector3.up, _currentRayLength);
        }
    }
}