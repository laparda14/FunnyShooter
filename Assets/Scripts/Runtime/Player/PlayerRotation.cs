using FunnyShooter.Core;
using UnityEngine;
using UnityEngine.Networking;

namespace FunnyShooter.Runtime {
    public class PlayerRotation : UnetBehaviour {
        private Vector3 eulerAngles;

        private void OnEnable() {
            Utility.Event.Subscribe(GameEventId.OnMoveXChange, OnGameEventHandler);
        }

        private void OnDisable() {
            Utility.Event.Unsubscribe(GameEventId.OnMoveXChange, OnGameEventHandler);
        }

        private void OnGameEventHandler(object sender, GameEventArgs e) {
            switch ((GameEventId)e.Id) {
                case GameEventId.OnMoveXChange:
                    GenericEventArgs<float> args = e as GenericEventArgs<float>;
                    if (args.Item > 0) {
                        eulerAngles.y = 0;
                        CmdSetEulerAnglesY(0);
                        transform.eulerAngles = eulerAngles;
                    } else if(args.Item < 0) {
                        eulerAngles.y = 180;
                        CmdSetEulerAnglesY(180);
                    }
                    break;
            }
        }

        [Command]
        private void CmdSetEulerAnglesY(float y) {
            eulerAngles = transform.eulerAngles;
            eulerAngles.y = y;
            RpcSyncRotation(eulerAngles);
        }

        [ClientRpc]
        private void RpcSyncRotation(Vector3 eulerAngles) {
            transform.eulerAngles = eulerAngles;
        }
    }
}