using FunnyShooter.Core;
using UnityEngine;

namespace FunnyShooter.Runtime {
    public class LaunchScene : MonoBehaviour {
        private void Start() {
            SceneManager.Instance.LoadScene("Main");
            UIManager.Instance.ShowWindow("TitleWindow", UIWindowType.Fix);
        }
    }
}