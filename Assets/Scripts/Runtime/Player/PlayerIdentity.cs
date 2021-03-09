using FunnyShooter.Core;
using UnityEngine;
using UnityEngine.Networking;

namespace FunnyShooter.Runtime {
    [RequireComponent(typeof(NetworkIdentity))]
    public class PlayerIdentity : UnetBehaviour {
        private NetworkIdentity networkIdentity;

        private void Awake() {
            networkIdentity = GetComponent<NetworkIdentity>();
        }

        public void Start() {
            if (!networkIdentity.isLocalPlayer) {
                enabled = false;
                GetComponent<PlayerAnimator>().enabled = false;
                GetComponent<PlayerCollider2D>().enabled = false;
                GetComponent<PlayerDamage>().enabled = false;
                GetComponent<PlayerInput>().enabled = false;
                GetComponent<PlayerJump>().enabled = false;
                GetComponent<PlayerMovement>().enabled = false;
                GetComponent<PlayerPhysics2D>().enabled = false;
                GetComponent<PlayerRigdbody2D>().enabled = false;
                GetComponent<PlayerRotation>().enabled = false;
                GetComponent<PlayerSpriteRenderer>().enabled = false;
            }
            SyncLocalPlayer();
        }

        public override void OnStartLocalPlayer() {
            base.OnStartLocalPlayer();
            Utility.Event.Fire(gameObject, GameEventId.OnStartLocalPlayer);
        }

        private void SyncLocalPlayer() {
            BroadcastMessage("OnSyncLocalPlayer", networkIdentity.isLocalPlayer);
        }
    }
}