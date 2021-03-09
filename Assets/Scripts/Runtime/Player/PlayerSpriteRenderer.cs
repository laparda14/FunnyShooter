using UnityEngine;
using FunnyShooter.Core;
using UnityEngine.Networking;

namespace FunnyShooter.Runtime {
    [RequireComponent(typeof(SpriteRenderer))]
    public class PlayerSpriteRenderer : UnetBehaviour {
        private SpriteRenderer spriteRenderer;

        private void Awake() {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnEnable() {
            Utility.Event.Subscribe(GameEventId.OnStartLocalPlayer, OnGameEventHandler);
            Utility.Event.Subscribe(GameEventId.OnPlayerDirctionChange, OnGameEventHandler);
        }

        private void OnDisable() {
            Utility.Event.Unsubscribe(GameEventId.OnStartLocalPlayer, OnGameEventHandler);
            Utility.Event.Unsubscribe(GameEventId.OnPlayerDirctionChange, OnGameEventHandler);
        }

        private void OnGameEventHandler(object sender, GameEventArgs e) {
            switch ((GameEventId)e.Id) {
                case GameEventId.OnStartLocalPlayer:
                    if (sender.Equals(gameObject)) {
                        spriteRenderer.color = Color.green;
                    }
                    break;
                case GameEventId.OnPlayerDirctionChange:
                    GenericEventArgs<bool> args2 = e as GenericEventArgs<bool>;
                    CmdSetFlipX(!args2.Item);
                    break;
            }
        }

        [Command]
        private void CmdSetFlipX(bool isFlipX) {
            RpcSyncFilpX(isFlipX);
        }

        [ClientRpc]
        private void RpcSyncFilpX(bool isFlipX) {
            spriteRenderer.flipX = isFlipX;
        }
    }
}