using UnityEngine;

namespace Scriptable {
    [CreateAssetMenu(menuName = "Settings/Scale", fileName = "Scale settings")]
    public class ScaleSettings : ScriptableObject {
        public Vector3 ScaleUpLimit;
        public Vector3 ScaleDownLimit;
        public float ScaleTime;
        public float SpeedRestore;
    }
}