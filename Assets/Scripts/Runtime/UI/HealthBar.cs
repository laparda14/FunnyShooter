using FunnyShooter.Core;
using UnityEngine;
using UnityEngine.UI;

namespace FunnyShooter.Runtime {
    public class HealthBar : MonoBehaviour {
        private object owner;
        [SerializeField]
        private Transform target;
        [SerializeField]
        private Slider slider;
        private RectTransform rectTransform;
        //private Vector2 lastTargtPosition;

        private void Awake() {
            rectTransform = GetComponent<RectTransform>();
        }

        private void OnEnable() {
            slider.value = 1;
            slider.gameObject.SetActiveSafe(false);
            Utility.Event.Subscribe(GameEventId.OnHealthChange, OnGameEventHandler);
            Utility.Event.Subscribe(GameEventId.OnPlayerDeath, OnGameEventHandler);
        }

        private void OnDisable() {
            Utility.Event.Unsubscribe(GameEventId.OnHealthChange, OnGameEventHandler);
            Utility.Event.Unsubscribe(GameEventId.OnPlayerDeath, OnGameEventHandler);
        }

        private void OnGameEventHandler(object sender, GameEventArgs e) {
            switch ((GameEventId)e.Id) {
                case GameEventId.OnHealthChange:
                    GenericEventArgs<Transform, float> args = e as GenericEventArgs<Transform, float>;
                    if (args.Item1 == target) {
                        slider.value = Utility.Math.Clamp01(args.Item2);
                    }
                    break;
                case GameEventId.OnPlayerDeath:
                    if (sender.Equals(owner)) {
                        GameObjectPoolManager.Instance.RecycleObj(gameObject);
                    }
                    break;
            }
        }

        public void Init(object owner, Transform target) {
            this.owner = owner;
            this.target = target;
            slider.gameObject.SetActiveSafe(true);
        }

        private void Update() {
            if (!target) {
                return;
            }
            //if (!Utility.Math.Approximately(target.position, lastTargtPosition)) {
            //    Vector2 pos = CameraManager.Instance.WorldToScreenPoint(target.position);
            //    rectTransform.position = pos;
            //    lastTargtPosition = target.position;
            //}
            Vector2 pos = CameraManager.Instance.WorldToScreenPoint(target.position);
            rectTransform.position = pos;
        }
    }
}