using FunnyShooter.Core;
using UnityEngine;

namespace FunnyShooter.Runtime {
    /// <summary>
    /// 相机震动器
    /// </summary>
    public class CameraShake : MonoBehaviour {
        private float shakeStrength;
        private float shakeDuration;
        private bool isShaked = false;
        private Vector3 deltaPositon;

        private const int ShakeAdjustValue = 100;

        private void OnEnable() {
            Utility.Event.Subscribe(GameEventId.OnCameraShake, OnGameEventHandler);
            Utility.Event.Subscribe(GameEventId.OnFireShake, OnGameEventHandler);
            Utility.Event.Subscribe(GameEventId.OnExplosionShake, OnGameEventHandler);
        }

        private void OnDisable() {
            Utility.Event.Unsubscribe(GameEventId.OnCameraShake, OnGameEventHandler);
            Utility.Event.Unsubscribe(GameEventId.OnFireShake, OnGameEventHandler);
            Utility.Event.Unsubscribe(GameEventId.OnExplosionShake, OnGameEventHandler);
        }

        private void Update() {
            if (isShaked) {
                //震动计时
                shakeDuration -= Time.deltaTime;
                if (shakeDuration < 0) {
                    isShaked = false;
                }

                transform.localPosition -= deltaPositon;
                deltaPositon = Random.insideUnitSphere / ShakeAdjustValue * shakeStrength;
                transform.localPosition += deltaPositon;
            }
        }

        /// <summary>
        /// 震动相机
        /// </summary>
        /// <param name="strength">震动强度</param>
        /// <param name="duration">震动持续时间</param>
        public void Shake(float strength, float duration) {
            //优先使用强度的震动
            if (shakeStrength > strength && isShaked) {
                return;
            }

            shakeStrength = strength;
            shakeDuration = duration;
            isShaked = true;
        }

        /// <summary>
        /// 枪械开火震动
        /// </summary>
        public void FireShake() {
            Shake(5, 0.2f);
        }

        /// <summary>
        /// 爆炸震动
        /// </summary>
        public void ExplosionShake() {
            Shake(10, 0.3f);
        }

        private void OnGameEventHandler(object sender, GameEventArgs e) {
            switch ((GameEventId)e.Id) {
                case GameEventId.OnCameraShake:
                    GenericEventArgs<float, float> args = e as GenericEventArgs<float, float>;
                    Shake(args.Item1, args.Item2);
                    break;
                case GameEventId.OnFireShake:
                    FireShake();
                    break;
                case GameEventId.OnExplosionShake:
                    ExplosionShake();
                    break;
            }
        }
    }
}