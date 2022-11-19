using UnityEngine;

namespace Services {
    [CreateAssetMenu(menuName = "Settings/Bouncy settings", fileName = "Bouncy settings")]
    public class BouncySettings : ScriptableObject {
        public PhysicMaterial BouncyMaterial;
    }
}