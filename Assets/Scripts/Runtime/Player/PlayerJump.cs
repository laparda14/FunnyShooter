using UnityEngine;
using FunnyShooter.Core;

namespace FunnyShooter.Runtime {
    [RequireComponent(typeof(PlayerRigdbody2D))]
    public class PlayerJump : UnetBehaviour {
        [SerializeField]
        private int jumpSpeed = 3;
        private PlayerRigdbody2D playerRigdbody2D;
        private PlayerPhysics2D playerPhysics2D;

        private void Awake() {
            playerRigdbody2D = GetComponent<PlayerRigdbody2D>();
            playerPhysics2D = GetComponent<PlayerPhysics2D>();
        }

        private void OnEnable() {
            Utility.Event.Subscribe(GameEventId.OnJumpChange, OnGameEventHandler);
        }

        private void OnDisable() {
            Utility.Event.Unsubscribe(GameEventId.OnJumpChange, OnGameEventHandler);
        }

        private void OnGameEventHandler(object sender, GameEventArgs e) {
            switch ((GameEventId)e.Id) {
                case GameEventId.OnJumpChange:
                    if (playerPhysics2D.IsGround) {
                        playerRigdbody2D.SetVelocityY(jumpSpeed);
                    }
                    break;
            }
        }
    }
}