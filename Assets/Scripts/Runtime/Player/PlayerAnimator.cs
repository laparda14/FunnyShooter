using UnityEngine;
using FunnyShooter.Core;

namespace FunnyShooter.Runtime {
    public class PlayerAnimator : UnetBehaviour {
        private Animator animator;

        private void Awake() {
            animator = GetComponent<Animator>();
        }

        private void OnEnable() {
            Utility.Event.Subscribe(GameEventId.OnMoveXInputChange, OnGameEventHandler);
            Utility.Event.Subscribe(GameEventId.OnVelocityXChange, OnGameEventHandler);
            Utility.Event.Subscribe(GameEventId.OnVelocityYChange, OnGameEventHandler);
            Utility.Event.Subscribe(GameEventId.OnGroundChange, OnGameEventHandler);
            Utility.Event.Subscribe(GameEventId.OnPlayerHit, OnGameEventHandler);
            Utility.Event.Subscribe(GameEventId.OnPlayerDeath, OnGameEventHandler);
        }

        private void OnDisable() {
            Utility.Event.Unsubscribe(GameEventId.OnMoveXInputChange, OnGameEventHandler);
            Utility.Event.Unsubscribe(GameEventId.OnVelocityXChange, OnGameEventHandler);
            Utility.Event.Unsubscribe(GameEventId.OnVelocityYChange, OnGameEventHandler);
            Utility.Event.Unsubscribe(GameEventId.OnGroundChange, OnGameEventHandler);
            Utility.Event.Unsubscribe(GameEventId.OnPlayerHit, OnGameEventHandler);
            Utility.Event.Unsubscribe(GameEventId.OnPlayerDeath, OnGameEventHandler);
        }

        private void OnGameEventHandler(object sender, GameEventArgs e) {
            switch ((GameEventId)e.Id) {
                case GameEventId.OnMoveXInputChange:
                    GenericEventArgs<float> args1 = e as GenericEventArgs<float>;
                    animator.SetFloat(AnimatorKey.VelocityX, Mathf.Abs(args1.Item));
                    break;
                case GameEventId.OnVelocityYChange:
                    GenericEventArgs<float> args2 = e as GenericEventArgs<float>;
                    animator.SetFloat(AnimatorKey.VelocityY, args2.Item);
                    break;
                case GameEventId.OnGroundChange:
                    GenericEventArgs<bool> args3 = e as GenericEventArgs<bool>;
                    animator.SetBool(AnimatorKey.IsGround, args3.Item);
                    break;
                case GameEventId.OnPlayerHit:
                    if (sender.Equals(gameObject)) {
                        animator.SetTrigger(AnimatorKey.OnHit);
                    }
                    break;
                case GameEventId.OnPlayerDeath:
                    if (sender.Equals(gameObject)) {
                        animator.SetBool(AnimatorKey.IsDeath, true);
                    }
                    break;
            }
        }
    }
}