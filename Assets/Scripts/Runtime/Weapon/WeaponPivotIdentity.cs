using UnityEngine;

namespace FunnyShooter.Runtime {
    public class WeaponPivotIdentity : MonoBehaviour {

        private void OnSyncLocalPlayer(bool isLocalPlayer) {
            if (!isLocalPlayer) {
                enabled = false;
                GetComponent<WeaponPivotRotation>().enabled = false;
            }
        }
    }
}