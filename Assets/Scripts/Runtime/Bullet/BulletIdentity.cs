using UnityEngine;
using UnityEngine.Networking;

namespace FunnyShooter.Runtime {
    public class BulletIdentity : MonoBehaviour {
        private NetworkIdentity networkIdentity;

        private void Awake() {
            networkIdentity = GetComponent<NetworkIdentity>();
        }
    }
}