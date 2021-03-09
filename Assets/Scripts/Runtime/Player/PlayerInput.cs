using UnityEngine;
using FunnyShooter.Core;

namespace FunnyShooter.Runtime {
    public class PlayerInput : UnetBehaviour {
        //private bool isMoveXChange = false;
        private Vector2 mousePosition;
        private Vector2 lastMousePosition;

        private void OnEnable() {
            Utility.Event.Subscribe(GameEventId.OnPlayerDeath, OnGameEventHandler);
        }

        private void OnDisable() {
            Utility.Event.Unsubscribe(GameEventId.OnPlayerDeath, OnGameEventHandler);
        }

        private void Update() {
            InputMoveX();
            InputJump();
            InputFire();
            InputMousePosition();
        }

        private void OnGameEventHandler(object sender, GameEventArgs e) {
            switch ((GameEventId)e.Id) {
                case GameEventId.OnPlayerDeath:
                    if (sender.Equals(gameObject)) {
                        enabled = false;
                    }
                    break;
            }
        }

        private void InputMoveX() {
            float moveX = InputManager.Instance.GetAxisRaw(InputKey.Horizontal);
            if (!Utility.Math.Approximately(moveX, 0f)) {
                Utility.Event.Fire(GameEventId.OnMoveXInputChange, moveX);
                // isMoveXChange = true;
            } else {// if (isMoveXChange) {
                Utility.Event.Fire(GameEventId.OnMoveXInputChange, 0f);
                // isMoveXChange = false;
            }
        }

        private void InputJump() {
            bool isJump = InputManager.Instance.GetButtonDown(InputKey.Jump);
            if (isJump) {
                Utility.Event.Fire(GameEventId.OnJumpInputChange);
            }
        }
        private void InputFire() {
            bool isFire = InputManager.Instance.GetButton(InputKey.Fire);
            if (isFire) {
                Utility.Event.Fire(GameEventId.OnFireInputChange);
            }
        }

        private void InputMousePosition() {
            mousePosition = InputManager.Instance.MousePosition;
            if (!Utility.Math.Approximately(mousePosition, lastMousePosition)) {
                Utility.Event.Fire(GameEventId.OnMousePositionChange, mousePosition);
            }
            lastMousePosition = mousePosition;
        }
    }
}