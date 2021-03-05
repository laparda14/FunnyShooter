using UnityEngine;
using FunnyShooter.Core;

namespace FunnyShooter.Runtime {
    public class PlayerInput : UnetBehaviour {
        private bool isMoveXChange = false;

        private void Update() {
            InputMoveX();
            InputJump();
        }

        private void InputMoveX() {
            float moveX = InputManager.Instance.GetAxisRaw(InputKey.Horizontal);
            if (!Mathf.Approximately(moveX, 0f)) {
                Utility.Event.Fire(GameEventId.OnMoveXChange, moveX);
                isMoveXChange = true;
            } else if (isMoveXChange) {
                Utility.Event.Fire(GameEventId.OnMoveXChange, 0f);
                isMoveXChange = false;
            }
        }

        private void InputJump() {
            bool isJump = InputManager.Instance.GetButtonDown(InputKey.Jump);
            if (isJump) {
                Utility.Event.Fire(GameEventId.OnJumpChange, isJump);
            }
        }
    }
}