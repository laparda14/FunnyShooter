namespace FunnyShooter.Runtime {
    public class WeaponIdentity : UnetBehaviour {

        private void OnSyncLocalPlayer(bool isLocalPlayer) {
            if (!isLocalPlayer) {
                enabled = false;
                GetComponent<WeaponSpriteRenderer>().enabled = false;
                GetComponent<WeaponAttack>().enabled = false;
            }
        }
    }
}