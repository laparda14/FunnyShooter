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

        private void OnEnable() {
            Utility.Event.Subscribe(GameEventId.OnTryGetClientAuthority, OnGameEventHandler);
        }

        private void OnDisable() {
            Utility.Event.Unsubscribe(GameEventId.OnTryGetClientAuthority, OnGameEventHandler);
        }

        public override void OnStartLocalPlayer() {
            base.OnStartLocalPlayer();
            Utility.Event.Fire(GameEventId.OnStartLocalPlayer, gameObject);
        }

        private void SyncLocalPlayer() {
            BroadcastMessage("OnSyncLocalPlayer", networkIdentity.isLocalPlayer);
        }

        private void OnGameEventHandler(object sender, GameEventArgs e) {
            switch ((GameEventId)e.Id) {
                case GameEventId.OnTryGetClientAuthority:
                    GenericEventArgs<GameObject> args = e as GenericEventArgs<GameObject>;
                    CmdGiveClientAuthority(args.Item);
                    break;
            }
        }

        [Command]
        private void CmdGiveClientAuthority(GameObject obj) {
            
        }
    }
}