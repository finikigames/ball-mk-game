using UnityEngine;

namespace Services {
    [CreateAssetMenu(fileName = "Settings/Bouncy")]
    public class BouncySettings : ScriptableObject {
        public PhysicMaterial BouncyMaterial;
    }
}