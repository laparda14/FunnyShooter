using FunnyShooter.Core;
using UnityEngine;
using UnityEngine.Networking;

namespace FunnyShooter.Runtime {
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerRigdbody2D : UnetBehaviour {
        private new Rigidbody2D rigidbody2D;
        [SerializeField]
        private Vector2 velocity;

        private bool isVelocityXChange;
        private bool isVelocityYChange;

        private void Awake() {
            rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void OnEnable() {
            Utility.Event.Subscribe(GameEventId.OnPlayerDeath, OnGameEventHandler);
        }

        private void OnDisable() {
            Utility.Event.Unsubscribe(GameEventId.OnPlayerDeath, OnGameEventHandler);
        }

        private void Update() {
            if (!Utility.Math.Approximately(rigidbody2D.velocity.x, 0f)) {
                Utility.Event.Fire(GameEventId.OnVelocityXChange, rigidbody2D.velocity.x);
                isVelocityXChange = true;
            } else if (isVelocityXChange) {
                Utility.Event.Fire(GameEventId.OnVelocityXChange, 0f);
                isVelocityXChange = false;
            }

            if (!Utility.Math.Approximately(rigidbody2D.velocity.y, 0f)) {
                Utility.Event.Fire(GameEventId.OnVelocityYChange, rigidbody2D.velocity.y);
                isVelocityYChange = true;
            } else if (isVelocityYChange) {
                Utility.Event.Fire(GameEventId.OnVelocityYChange, 0f);
                isVelocityYChange = false;
            }
        }

        private void OnGameEventHandler(object sender, GameEventArgs e) {
            switch ((GameEventId)e.Id) {
                case GameEventId.OnPlayerDeath:
                    if (sender.Equals(gameObject)) {
                        enabled = false;
                        CmdSetBodyType(RigidbodyType2D.Static);
                    }
                    break;
            }
        }

        public void SetVelocity(Vector2 velocity) {
            rigidbody2D.velocity = velocity;
        }

        public void SetVelocityX(float velocityX) {
            velocity = rigidbody2D.velocity;
            velocity.x = velocityX;
            rigidbody2D.velocity = velocity;
        }

        public void SetVelocityY(float velocityY) {
            velocity = rigidbody2D.velocity;
            velocity.y = velocityY;
            rigidbody2D.velocity = velocity;
        }

        [Command]
        private void CmdSetBodyType(RigidbodyType2D bodyType) {
            RpcSetBodyType(bodyType);
        }

        [ClientRpc]
        private void RpcSetBodyType(RigidbodyType2D bodyType) {
            rigidbody2D.bodyType = RigidbodyType2D.Static;
        }
    }
}