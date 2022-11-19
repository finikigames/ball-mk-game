using UnityEngine;

namespace Scriptable {
    [CreateAssetMenu(fileName = "Settings/Scale")]
    public class ScaleSettings : ScriptableObject {
        public Vector3 ScaleUpLimit;
        public Vector3 ScaleDownLimit;
        public float ScaleTime;
        public float SpeedRestore;
    }
}