using UnityEngine;
using FunnyShooter.Core;
using UnityEngine.Networking;

namespace FunnyShooter.Runtime {
    public class WeaponAttack : UnetBehaviour {
        [SerializeField]
        private EffectDisplayNonRecycler flashEffectDisplay;
        [SerializeField]
        private Transform muzzle;
        [SerializeField]
        private WeaponPivotRotation weaponPivotRotation;
        [SerializeField]
        private float shootRate = 1;
        private float shootCoolTimer;

        private void OnEnable() {
            Utility.Event.Subscribe(GameEventId.OnFireInputChange, OnGameEventHandler);
        }

        private void OnDisable() {
            Utility.Event.Unsubscribe(GameEventId.OnFireInputChange, OnGameEventHandler);
        }

        private void Update() {
            if (shootCoolTimer > 0) {
                shootCoolTimer -= Time.deltaTime;
            }
        }

        private void OnGameEventHandler(object sender, GameEventArgs e) {
            switch ((GameEventId)e.Id) {
                case GameEventId.OnFireInputChange:
                    Fire();
                    break;
            }
        }

        public void Fire() {
            if (shootCoolTimer > 0) {
                return;
            }
            shootCoolTimer = 1 / shootRate;
            Utility.Event.Fire(GameEventId.OnFireShake);
            CmdFireDisplay();
        }

        [Command]
        private void CmdFireDisplay() {
            RpcFireDisplay();
        }

        [ClientRpc]
        private void RpcFireDisplay() {
            SoundManager.Instance.PlayerSource("Shoot", transform.position);
            flashEffectDisplay.ShowEffect();
            GameObject bullet = GameObjectPoolManager.Instance.SpawnObj("Bullet");
            bullet.transform.position = muzzle.position;
            bullet.transform.right = weaponPivotRotation.Direction;
        }
    }
}