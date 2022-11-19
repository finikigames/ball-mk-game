using UnityEngine;

namespace Services {
    [CreateAssetMenu(menuName = "Settings/Tetra settings", fileName = "Tetra settings")]
    public class TetraSettings : ScriptableObject {
        public Mesh TetraMesh;
    }
}