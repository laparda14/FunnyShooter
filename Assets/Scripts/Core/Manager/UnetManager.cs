using FunnyShooter.Runtime;
using UnityEngine;
using UnityEngine.Networking;

namespace FunnyShooter.Core {
    public class UnetManager : NetworkManager {
        private static UnetManager instance;
        private bool isHost;

        public static UnetManager Instance {
            get {
                if (instance == null) {
                    instance = FindObjectOfType<UnetManager>();
                    if (instance == null) {
                        instance = new GameObject("UnetManager").AddComponent<UnetManager>();
                    }
                }
                return instance;
            }
        }

        private void Awake() {
            if (instance == null) {
                instance = this;
            } else if (instance != this) {
                Destroy(gameObject);
            }
        }

        public void CustomStartHost() {
            isHost = true;
            StartHost();
            Utility.Event.Fire(GameEventId.OnRecycleAllObjects);
        }

        public void CustomStartClient() {
            isHost = false;
            StartClient();
            Utility.Event.Fire(GameEventId.OnRecycleAllObjects);
        }

        public void CustomStop() {
            if (isHost) {
                StopHost();
            } else {
                StopClient();
            }
        }

        //public virtual void OnClientConnect(NetworkConnection conn);
        public override void OnClientDisconnect(NetworkConnection conn) {
            base.OnClientDisconnect(conn);
            Utility.Log.Debug("UnetManager.OnClientDisconnect");
        }
        //public virtual void OnClientError(NetworkConnection conn, int errorCode);
        //public virtual void OnClientNotReady(NetworkConnection conn);
        //public virtual void OnClientSceneChanged(NetworkConnection conn);
        //public virtual void OnServerAddPlayer(NetworkConnection conn, short playerControllerId);
        //public virtual void OnServerConnect(NetworkConnection conn);
        public override void OnServerDisconnect(NetworkConnection conn) {
            base.OnServerDisconnect(conn);
            Utility.Event.Fire(GameEventId.OnServerDisconnect);
            Utility.Log.Debug("UnetManager.OnServerDisconnect");
        }
        //public virtual void OnServerError(NetworkConnection conn, int errorCode);
        //public virtual void OnServerReady(NetworkConnection conn);
        //public virtual void OnServerRemovePlayer(NetworkConnection conn, PlayerController player);
        //public virtual void OnServerSceneChanged(string sceneName);

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