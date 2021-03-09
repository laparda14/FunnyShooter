using FunnyShooter.Core;
using UnityEngine;
using UnityEngine.Networking;

namespace FunnyShooter.Runtime {
    [RequireComponent(typeof(Collider2D))]
    public class PlayerCollider2D : UnetBehaviour {
        private new Collider2D collider2D;

        public Bounds Bounds {
            get {
                return collider2D.bounds;
            }
        }

        private void Awake() {
            collider2D = GetComponent<Collider2D>();
        }

        private void OnEnable() {
            Utility.Event.Subscribe(GameEventId.OnPlayerDeath, OnGameEventHandler);
        }

        private void OnDisable() {
            Utility.Event.Unsubscribe(GameEventId.OnPlayerDeath, OnGameEventHandler);
        }

        private void OnGameEventHandler(object sender, GameEventArgs e) {
            switch ((GameEventId)e.Id) {
                case GameEventId.OnPlayerDeath:
                    if (sender.Equals(gameObject)) {
                        CmdSetCollider2DEnable(false);
                    }
                    break;
            }
        }

        [Command]
        private void CmdSetCollider2DEnable(bool enabled) {
            RpcSetCollider2DEnable(enabled);
        }

        [ClientRpc]
        private void RpcSetCollider2DEnable(bool enabled) {
            collider2D.enabled = false;
        }
    }
}