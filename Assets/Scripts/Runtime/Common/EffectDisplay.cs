using UnityEngine;

namespace FunnyShooter.Runtime {
    /// <summary>
    /// 特效显示器，可回收
    /// </summary>
    [RequireComponent(typeof(Animator))]
    public class EffectDisplay : GameObjectPoolRecycler {
        [Header("设置决定特效触发的参数")]
        public string effectTriggerParame;

        private Animator animator;

        protected override void Awake() {
            base.Awake();
            animator = GetComponent<Animator>();
        }

        public void ShowEffect() {
            animator.ResetTrigger(effectTriggerParame);
            animator.SetTrigger(effectTriggerParame);
        }
    }
}