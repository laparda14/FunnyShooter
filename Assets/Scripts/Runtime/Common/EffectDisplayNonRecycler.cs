using UnityEngine;

namespace FunnyShooter.Runtime {
    /// <summary>
    /// 特效显示器，不可回收
    /// </summary>
    [RequireComponent(typeof(Animator))]
    public class EffectDisplayNonRecycler : MonoBehaviour {
        [Header("设置决定特效触发的参数")]
        public string effectTriggerParame;

        private Animator animator;

        private void Awake() {
            animator = GetComponent<Animator>();
        }

        public void ShowEffect() {
            animator.ResetTrigger(effectTriggerParame);
            animator.SetTrigger(effectTriggerParame);
        }
    }
}