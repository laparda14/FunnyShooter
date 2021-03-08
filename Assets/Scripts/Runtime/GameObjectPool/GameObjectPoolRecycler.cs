using FunnyShooter.Core;
using System.Collections;
using UnityEngine;

namespace FunnyShooter.Runtime {
    public class GameObjectPoolRecycler : MonoBehaviour {
        [Header("持续多长时间就会被回收，当为零时表示不会自动回收")]
        public float duration = 1;
        private WaitForSeconds waitForSecondsToRecovery;

        protected virtual void Awake() {
            waitForSecondsToRecovery = new WaitForSeconds(duration);
        }

        private void OnEnable() {
            Utility.Event.Subscribe(GameEventId.OnRecycleAllObjects, OnGameEventHandler);

            if (duration == 0) {
                return;
            }

            StopAllCoroutines();
            StartCoroutine(Recovery());
        }

        private void OnDisable() {
            Utility.Event.Unsubscribe(GameEventId.OnRecycleAllObjects, OnGameEventHandler);
        }

        public void RecycleObj() {
            GameObjectPoolManager.Instance.RecycleObj(gameObject);
        }

        private IEnumerator Recovery() {
            yield return waitForSecondsToRecovery;
            GameObjectPoolManager.Instance.RecycleObj(gameObject);
        }

        private void OnGameEventHandler(object sender, GameEventArgs e) {
            switch ((GameEventId)e.Id) {
                case GameEventId.OnStartLocalPlayer:
                    RecycleObj();
                    break;
            }
        }

    }
}