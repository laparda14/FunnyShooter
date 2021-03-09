using FunnyShooter.Core;
using UnityEngine;

namespace FunnyShooter.Runtime {
    public class MainScene : MonoBehaviour {
        private void Start() {
            UIManager.Instance.ShowWindow("LoginWindow");
        }
    }
}