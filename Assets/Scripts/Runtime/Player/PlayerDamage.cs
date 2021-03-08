using UnityEngine;
using UnityEngine.Networking;
using FunnyShooter.Core;

namespace FunnyShooter.Runtime {
    public class PlayerDamage : UnetBehaviour {
        [SerializeField]
        private float maxHealth = 10;
        [SyncVar]
        [SerializeField]
        private float currentHealth;

        private void Start() {
            currentHealth = maxHealth;
        }

        private void OnEnable() {
            Utility.Event.Subscribe(GameEventId.OnPlayerHit, OnGameEventHandler);
        }

        private void OnDisable() {
            Utility.Event.Unsubscribe(GameEventId.OnPlayerHit, OnGameEventHandler);
        }

        private void OnGameEventHandler(object sender, GameEventArgs e) {
            switch ((GameEventId)e.Id) {
                case GameEventId.OnPlayerHit:
                    GenericEventArgs<GameObject> args = e as GenericEventArgs<GameObject>;
                    if (args.Item == gameObject) {
                        CmdGetDamage();
                    }
                    break;
            }
        }

        [Command]
        private void CmdGetDamage() {
            currentHealth--;
        }
    }
}