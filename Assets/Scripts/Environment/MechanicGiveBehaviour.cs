using DefaultNamespace.Settings;
using Extensions;
using UnityEngine;

namespace DefaultNamespace.Environment {
    public class MechanicGiveBehaviour : MonoBehaviour {
        public MechanicType Type;
        
        private string _playerTag;

        private void OnTriggerEnter(Collider other) {
            _playerTag = "Player";
            if (other.CompareTag(_playerTag)) {
                var mechanicsSettings = ApplicationService.Instance.MechanicsSettings;
                var mechanicType = mechanicsSettings.Mechanics[Type];
                other.gameObject.AddComponentLazy(mechanicType);
            }
        }
    }
}