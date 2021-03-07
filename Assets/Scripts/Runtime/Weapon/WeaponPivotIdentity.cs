namespace FunnyShooter.Runtime {
    public class WeaponPivotIdentity : UnetBehaviour {

        private void OnSyncLocalPlayer(bool isLocalPlayer) {
            if (!isLocalPlayer) {
                enabled = false;
                GetComponent<WeaponPivotRotation>().enabled = false;
            }
        }
    }
}