using UnityEngine;
using FunnyShooter.Core;

namespace FunnyShooter.Runtime {
    /// <summary>
    /// 镜头跟随器
    /// </summary>
    public class CameraFollowTarget : MonoBehaviour {
        [SerializeField]
        private Transform target;
        [SerializeField]
        private float offest;
        [SerializeField]
        private float followSpeed = 5f;
        private Vector3 realOffset;

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
                    target = ((GameObject)sender).transform;
                    break;
                case GameEventId.OnDirctionChange:
                    GenericEventArgs<Vector2> args2 = e as GenericEventArgs<Vector2>;
                    realOffset = args2.Item * offest;
                    break;
            }
        }
    }
}