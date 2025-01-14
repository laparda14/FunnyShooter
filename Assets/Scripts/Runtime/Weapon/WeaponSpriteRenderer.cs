﻿using UnityEngine;
using FunnyShooter.Core;
using UnityEngine.Networking;

namespace FunnyShooter.Runtime {
    public class WeaponSpriteRenderer : UnetBehaviour {
        public SpriteRenderer spriteRenderer;


        private void OnEnable() {
            Utility.Event.Subscribe(GameEventId.OnWeaponDirctionChange, OnGameEventHandler);
        }

        private void OnDisable() {
            Utility.Event.Unsubscribe(GameEventId.OnWeaponDirctionChange, OnGameEventHandler);
        }

        private void OnGameEventHandler(object sender, GameEventArgs e) {
            switch ((GameEventId)e.Id) {
                case GameEventId.OnWeaponDirctionChange:
                    GenericEventArgs<bool> args = e as GenericEventArgs<bool>;
                    CmdSetFlipY(!args.Item);
                    break;
            }
        }

        [Command]
        private void CmdSetFlipY(bool isFlipY) {
            RpcSyncFilpY(isFlipY);
        }

        [ClientRpc]
        private void RpcSyncFilpY(bool isFlipY) {
            spriteRenderer.flipY = isFlipY;
        }
    }
}