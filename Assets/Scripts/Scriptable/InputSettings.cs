using DigitalRubyShared;
using UnityEngine;

namespace Scriptable {
    [CreateAssetMenu(fileName = "Input settings", menuName = "Settings/Input settings")]
    public class InputSettings : ScriptableObject {
        public MobileInputProvider InputPrefab;
    }
}