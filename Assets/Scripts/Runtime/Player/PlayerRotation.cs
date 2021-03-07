using FunnyShooter.Core;
using UnityEngine;
using UnityEngine.Networking;

namespace FunnyShooter.Runtime {
    [RequireComponent(typeof(PlayerSpriteRenderer))]
    public class PlayerRotation : UnetBehaviour {
        private PlayerSpriteRenderer playerSpriteRenderer;
        private bool isFaceToRight;

        private void Awake() {
            playerSpriteRenderer = GetComponent<PlayerSpriteRenderer>();
        }

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