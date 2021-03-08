using UnityEngine;

namespace FunnyShooter.Core {
    public class UIWindowBase : MonoBehaviour {
        public UIData UIData { get; private set; }

        public void InitData(UIData data) {
            UIData = data;
            OnInitData();
        }

        public virtual void OnInitData() {

        }

        public virtual void OnCreat() {
        }

        public virtual void OnClose() {
        }

        public virtual void OnShow() {
        }

        public virtual void OnHide() {
        }

        public virtual void OnUpdate() {
        }
    }
}