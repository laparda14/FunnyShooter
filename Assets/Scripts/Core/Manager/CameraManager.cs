using UnityEngine;

namespace FunnyShooter.Core {
    public class CameraManager : Singleton<CameraManager> {

        public Camera MainCamera {
            get {
                return Camera.main;
            }
        }

        public Vector3 WorldToScreenPoint(Vector3 position) {
            return Camera.main.WorldToScreenPoint(position);
        }
    }
}