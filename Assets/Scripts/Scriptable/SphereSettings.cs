using UnityEngine;

namespace Scriptable {
    [CreateAssetMenu(fileName = "Sphere settings", menuName = "Settings/Sphere settings")]
    public class SphereSettings : ScriptableObject {
        public Mesh SphereMesh;
    }
}