using UnityEngine;
using UnityEngine.Networking;
using FunnyShooter.Core;

namespace FunnyShooter.Runtime {
    public class WeaponPivotRotation : UnetBehaviour {
        [SerializeField]
        private Transform pivot;
        [SerializeField]
        public float rotateSpeed = 10;
        [SyncVar]
        private Vector2 direction;
        private Vector2 position;
        private bool isFaceToRight = true;

        public Vector2 Direction {
            get {
                return direction;
            }
        }

        private void OnEnable() {
            Utility.Event.Subscribe(GameEventId.OnMousePositionChange, OnGameEventHandler);
        }

        private void OnDisable() {
            Utility.Event.Unsubscribe(GameEventId.OnMousePositionChange, OnGameEventHandler);
        }

        private void Update() {
            if (!Utility.Math.Approximately(pivot.transform.right, direction)) {
                pivot.transform.right = Vector2.Lerp(pivot.transform.right, direction, rotateSpeed * Time.deltaTime);
                float result = Vector2.Dot(pivot.transform.right, Vector2.right);
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
                    position = CameraManager.Instance.WorldToScreenPoint(pivot.transform.position);
                    CmdSetDirection((args.Item - position).normalized);
                    break;
            }
        }

        [Command]
        private void CmdSetDirection(Vector2 direction) {
            this.direction = direction;
        }
    }
}