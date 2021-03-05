using FunnyShooter.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FunnyShooter.Runtime {
    public class Launch : MonoBehaviour {
        private void Awake() {
            SceneManager.Instance.LoadScene("Main");
        }
    }
}