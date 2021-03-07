using UnityEngine;
using FunnyShooter.Core;

namespace FunnyShooter.Runtime {
    public class WeaponPivotRotation : UnetBehaviour {
        [SerializeField]
        public float rotateSpeed = 10;

        private Vector2 direction;
        private Vector2 position;
        private bool isFaceToRight = true;

        private void OnEnable() {
            Utility.Event.Subscribe(GameEventId.OnMousePositionChange, OnGameEventHandler);
        }

        private void OnDisable() {
            Utility.Event.Unsubscribe(GameEventId.OnMousePositionChange, OnGameEventHandler);
        }

        private void Update() {
            if (!Utility.Math.Approximately(transform.right, direction)) {
                transform.right = Vector2.Lerp(transform.right, direction, rotateSpeed * Time.deltaTime);
                float result = Vector2.Dot(transform.right, Vector2.right);
                if (result > 0 && !isFaceToRight) {
                    isFaceToRight = true;
                    Utility.Event.Fire(GameEventId.OnWeaponDirctionChange, isFaceToRight);
                } else if(result < 0 && isFaceToRight) {
                    isFaceToRight = false;
                    Utility.Event.Fire(GameEventId.OnWeaponDirctionChange, isFaceToRight);
                }
            }
        }

        private void OnGameEventHandler(object sender, GameEventArgs e) {
            switch ((GameEventId)e.Id) {
                case GameEventId.OnMousePositionChange:
                    GenericEventArgs<Vector2> args = e as GenericEventArgs<Vector2>;
                    position = CameraManager.Instance.WorldToScreenPoint(transform.position);
                    direction = (args.Item - position).normalized;
                    break;
            }
        }
    }
}