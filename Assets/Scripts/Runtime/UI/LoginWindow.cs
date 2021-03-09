using FunnyShooter.Core;

namespace FunnyShooter.Runtime {
    public class LoginWindow : UIWindowBase {
        public void OnHostBtnClick() {
            UnetManager.Instance.CustomStartHost();
            HideWindow();
        }

        public void OnClientBtnClick() {
            UnetManager.Instance.CustomStartClient();
            HideWindow();
        }

        public void HideWindow() {
            UIManager.Instance.HideWindow(UIData.WindowName);
        }
    }
}