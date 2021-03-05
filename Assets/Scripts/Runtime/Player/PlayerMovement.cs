using UnityEngine;
using FunnyShooter.Core;

namespace FunnyShooter.Runtime {
    [RequireComponent(typeof(PlayerRigdbody2D))]
    public class PlayerMovement : UnetBehaviour {
        [SerializeField]
        private int moveSpeed = 3;
        private PlayerRigdbody2D playerRigdbody2D;
        private PlayerPhysics2D playerPhysics2D;

        private void Awake() {
            playerRigdbody2D = GetComponent<PlayerRigdbody2D>();
            playerPhysics2D = GetComponent<PlayerPhysics2D>();
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
                    playerRigdbody2D.SetVelocityX(args.Item * moveSpeed);
                    break;
            }
        }
    }
}