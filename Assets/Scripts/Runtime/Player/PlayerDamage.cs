using UnityEngine;
using UnityEngine.Networking;
using FunnyShooter.Core;

namespace FunnyShooter.Runtime {
    public class PlayerDamage : UnetBehaviour {
        [SerializeField]
        private int maxHealth = 10;
        [SerializeField][SyncVar(hook = "OnHealthChange")]
        private int currentHealth;
        [SerializeField]
        private Transform healthBarTarget;

        private void Start() {
            CmdRestoreMaxHealth();
            Utility.Event.Fire(gameObject, GameEventId.OnHealthBarCreate, healthBarTarget);
        }

        private void OnEnable() {
            Utility.Event.Subscribe(GameEventId.OnPlayerHit, OnGameEventHandler);
        }

        private void OnDisable() {
            Utility.Event.Unsubscribe(GameEventId.OnPlayerHit, OnGameEventHandler);
        }

        private void OnGameEventHandler(object sender, GameEventArgs e) {
            switch ((GameEventId)e.Id) {
                case GameEventId.OnPlayerHit:
                    if (sender.Equals(gameObject)) {
                        GetDamage();
                    }
                    break;
            }
        }

        public void GetDamage() {
            CmdChangeHealth(-1);
        }

        [Command]
        public void CmdChangeHealth(int health) {
            currentHealth = Utility.Math.Clamp(currentHealth + health, 0, maxHealth);
        }

        [Command]
        public void CmdRestoreMaxHealth() {
            currentHealth = maxHealth;
        }

        private void OnHealthChange(int currentHealth) {
            Utility.Event.Fire(GameEventId.OnHealthChange, healthBarTarget, currentHealth / (float)maxHealth);
            if (currentHealth <= 0) {
                Utility.Event.Fire(gameObject, GameEventId.OnPlayerDeath);
            }
        }
    }
}