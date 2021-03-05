using UnityEngine.Networking;

namespace FunnyShooter.Core {
    public class UnetManager : NetworkManager {
        public override void OnStartClient(NetworkClient client) {
            base.OnStartClient(client);
            Utility.Log.Debug("UnetManager.OnStartClient");
        }

        public override void OnStartHost() {
            base.OnStartHost();
            Utility.Log.Debug("UnetManager.OnStartHost");
        }

        public override void OnStartServer() {
            base.OnStartServer();
            Utility.Log.Debug("UnetManager.OnStartServer");
        }

        public override void OnStopClient() {
            base.OnStopClient();
            Utility.Log.Debug("UnetManager.OnStopClient");
        }

        public override void OnStopHost() {
            base.OnStopHost();
            Utility.Log.Debug("UnetManager.OnStopHost");
        }

        public override void OnStopServer() {
            base.OnStopServer();
            Utility.Log.Debug("UnetManager.OnStopServer");
        }
    }
}