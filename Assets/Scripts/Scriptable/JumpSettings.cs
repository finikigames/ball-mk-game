using UnityEngine;

namespace Scriptable {
    [CreateAssetMenu(menuName = "Settings/Jump settings", fileName = "Jump settings")]
    public class JumpSettings : ScriptableObject {
        public float DoubleJumpPower;
    }
}