using FunnyShooter.Core;
using UnityEngine;

namespace FunnyShooter.Runtime {
    [RequireComponent(typeof(PlayerSpriteRenderer))]
    public class PlayerRotation : UnetBehaviour {
        private bool isFaceToRight = true;
        private Vector2 position;
        private Vector2 direction;

        private void OnEnable() {
            Utility.Event.Subscribe(GameEventId.OnMousePositionChange, OnGameEventHandler);
        }

        private void OnDisable() {
            Utility.Event.Unsubscribe(GameEventId.OnMousePositionChange, OnGameEventHandler);
        }

        private void OnGameEventHandler(object sender, GameEventArgs e) {
            switch ((GameEventId)e.Id) {
                case GameEventId.OnMousePositionChange:
                    GenericEventArgs<Vector2> args = e as GenericEventArgs<Vector2>;
                    position = CameraManager.Instance.WorldToScreenPoint(transform.position);
                    direction = (args.Item - position).normalized;
                    float result = Vector2.Dot(direction, Vector2.right);
                    if (result > 0 && !isFaceToRight) {
                        isFaceToRight = true;
                        Utility.Event.Fire(GameEventId.OnPlayerDirctionChange, isFaceToRight);
                    } else if (result < 0 && isFaceToRight) {
                        isFaceToRight = false;
                        Utility.Event.Fire(GameEventId.OnPlayerDirctionChange, isFaceToRight);
                    }
                    Utility.Event.Fire(GameEventId.OnDirctionChange, direction);
                    break;
            }
        }
    }
}