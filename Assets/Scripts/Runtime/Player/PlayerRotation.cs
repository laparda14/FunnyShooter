using FunnyShooter.Core;
using UnityEngine;

namespace FunnyShooter.Runtime {
    [RequireComponent(typeof(PlayerSpriteRenderer))]
    public class PlayerRotation : UnetBehaviour {
        private bool isFaceToRight = true;

        private void OnEnable() {
            Utility.Event.Subscribe(GameEventId.OnMoveXInputChange, OnGameEventHandler);
        }

        private void OnDisable() {
            Utility.Event.Unsubscribe(GameEventId.OnMoveXInputChange, OnGameEventHandler);
        }

        private void OnGameEventHandler(object sender, GameEventArgs e) {
            switch ((GameEventId)e.Id) {
                case GameEventId.OnMoveXInputChange:
                    GenericEventArgs<float> args = e as GenericEventArgs<float>;
                    if (args.Item > 0 && !isFaceToRight) {
                        isFaceToRight = true;
                        Utility.Event.Fire(GameEventId.OnDirctionChange, isFaceToRight);
                    } else if(args.Item < 0 && isFaceToRight) {
                        isFaceToRight = false;
                        Utility.Event.Fire(GameEventId.OnDirctionChange, isFaceToRight);
                    }
                    break;
            }
        }
    }
}