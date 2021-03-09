using UnityEngine;

namespace FunnyShooter.Core {
    public abstract class UIWindowBase : MonoBehaviour {
        public UIData UIData { get; private set; }

        private void Update() {
            OnUpdateWindow();
        }

        public void InitData(UIData data) {
            UIData = data;
            OnInitData();
        }

        public virtual void OnInitData() {

        }

        public virtual void OnCreatWindow() {
        }

        public virtual void OnCloseWindow() {
            ReferencePool.Release(UIData);
        }

        public virtual void OnShowWindow() {
        }

        public virtual void OnHideWindow() {
        }

        public virtual void OnUpdateWindow() {
        }
    }
}