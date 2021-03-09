using FunnyShooter.Core;
using UnityEngine;

namespace FunnyShooter.Runtime {
    public class BattleScene : MonoBehaviour {
        private void Start() {
            UIManager.Instance.ShowWindow("BattleWindow");
        }
    }
}