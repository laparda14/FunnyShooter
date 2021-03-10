using FunnyShooter.Core;

namespace FunnyShooter.Runtime {
    public class LoginWindow : UIWindowBase {
        public void OnHostBtnClick() {
            SoundManager.Instance.PlayerSource("OnClickSound");
            UnetManager.Instance.CustomStartHost();
            HideWindow();
        }

        public void OnClientBtnClick() {
            SoundManager.Instance.PlayerSource("OnClickSound");
            UnetManager.Instance.CustomStartClient();
            HideWindow();
        }

        public void HideWindow() {
            UIManager.Instance.HideWindow(UIData.WindowName);
        }
    }
}