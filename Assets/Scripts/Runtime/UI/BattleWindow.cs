using FunnyShooter.Core;
using UnityEngine;

namespace FunnyShooter.Runtime {
    public class BattleWindow : UIWindowBase {
        [SerializeField]
        private Transform healthBarNode;
        private void OnEnable() {
            Utility.Event.Subscribe(GameEventId.OnHealthBarCreate, OnGameEventHandler);
            Utility.Event.Subscribe(GameEventId.OnServerDisconnect, OnGameEventHandler);
        }

        private void OnDisable() {
            Utility.Event.Unsubscribe(GameEventId.OnHealthBarCreate, OnGameEventHandler);
            Utility.Event.Unsubscribe(GameEventId.OnServerDisconnect, OnGameEventHandler);
        }

        private void OnGameEventHandler(object sender, GameEventArgs e) {
            switch ((GameEventId)e.Id) {
                case GameEventId.OnHealthBarCreate:
                    GenericEventArgs<Transform> args = e as GenericEventArgs<Transform>;
                    HealthBar healthBar = GameObjectPoolManager.Instance.SpawnObj<HealthBar>("HealthBar");
                    healthBar.transform.SetParent(healthBarNode);
                    healthBar.transform.LocalReset();
                    healthBar.Init(sender, args.Item);
                    break;
                case GameEventId.OnServerDisconnect:
                    OnStopBtnClick();
                    break;
            }
        }

        public void OnStopBtnClick() {
            UnetManager.Instance.CustomStop();
            SceneManager.Instance.LoadScene("Main");
            Utility.Event.FireNow(GameEventId.OnRecycleAllObjects);
            HideWindow();
        }

        public void HideWindow() {
            UIManager.Instance.HideWindow(UIData.WindowName);
        }
    }
}