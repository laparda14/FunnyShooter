using UnityEngine;
using UnityEngine.Networking;

namespace FunnyShooter.Runtime {
    [RequireComponent(typeof(PlayerCollider2D))]
    public class BulletPhysics2D : MonoBehaviour {
        private void OnCollisionEnter2D(Collision2D collision) {
            GameObjectPoolManager.Instance.RecycleObj(gameObject);
            //显示击中特效
            bool isHitFXShowed = false;
            foreach (ContactPoint2D point2D in collision.contacts) {
                if (isHitFXShowed) {
                    break;
                }
                EffectDisplay effectDisplay = GameObjectPoolManager.Instance.SpawnObj<EffectDisplay>("Hit");
                effectDisplay.transform.position = new Vector3(point2D.point.x, point2D.point.y, 0);
                effectDisplay.ShowEffect();
                isHitFXShowed = true;
            }
        }
    }
}