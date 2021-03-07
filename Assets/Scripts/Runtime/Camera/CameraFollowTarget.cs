using UnityEngine;
using FunnyShooter.Core;

namespace FunnyShooter.Runtime {
    /// <summary>
    /// 镜头跟随器
    /// </summary>
    public class CameraFollowTarget : MonoBehaviour {
        public Transform target;
        public Vector3 offest;
        public float followSpeed = 5f;
        private Vector3 realOffset;

        private void Start() {
            offest.z = 0;
            realOffset = offest;
        }

        private void OnEnable() {
            Utility.Event.Subscribe(GameEventId.OnStartLocalPlayer, OnGameEventHandler);
            Utility.Event.Subscribe(GameEventId.OnDirctionChange, OnGameEventHandler);
        }

        private void OnDisable() {
            Utility.Event.Unsubscribe(GameEventId.OnStartLocalPlayer, OnGameEventHandler);
            Utility.Event.Unsubscribe(GameEventId.OnDirctionChange, OnGameEventHandler);
        }

        private void LateUpdate() {
            if (!target) { return; }
            Vector3 targetPosition = target.position + realOffset;
            targetPosition.z = transform.position.z;
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }

        private void OnGameEventHandler(object sender, GameEventArgs e) {
            switch ((GameEventId)e.Id) {
                case GameEventId.OnStartLocalPlayer:
                    GenericEventArgs<GameObject> args1 = e as GenericEventArgs<GameObject>;
                    target = args1.Item.transform;
                    break;
                case GameEventId.OnDirctionChange:
                    GenericEventArgs<bool> args2 = e as GenericEventArgs<bool>;
                    realOffset = offest;
                    realOffset.x *= args2.Item ? 1 : -1;
                    break;
            }
        }
    }
}