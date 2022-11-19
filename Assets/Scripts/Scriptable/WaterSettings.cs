using UnityEngine;

namespace Scriptable {
    [CreateAssetMenu(menuName = "Settings/Water settings", fileName = "Water settings")]
    public class WaterSettings : ScriptableObject{
        public float WaterLevel = 1.5f;
        public float FloatHeight = 1f;
        public Vector3 BuoyancyCenterOffset;
        public float BounceDamp;
        public float SpeedDownPercent = 0.7f;
        public float JumpDownPercent = 0.9f;
    }
}