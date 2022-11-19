using UnityEngine;

namespace Services {
    [CreateAssetMenu(menuName = "Settings/Box settings", fileName = "Box settings")]
    public class BoxSettings : ScriptableObject {
        public Mesh BoxMesh;
    }
}