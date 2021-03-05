using UnityEngine;

namespace FunnyShooter.Core {
    public class InputManager : Singleton<InputManager> {
        

        public float GetAxis(string axisName) {
            return Input.GetAxis(axisName);
        }

        public float GetAxisRaw(string axisName) {
            return Input.GetAxisRaw(axisName);
        }

        public bool GetButton(string buttonName) {
            return Input.GetButton(buttonName);
        }

        public bool GetButtonDown(string buttonName) {
            return Input.GetButtonDown(buttonName);
        }

        public bool GetButtonUp(string buttonName) {
            return Input.GetButtonUp(buttonName);
        }
    }
}