using UnityEngine;

namespace FunnyShooter.Runtime {
    public class BulletMove : MonoBehaviour {
        [SerializeField]
        private float moveSpeed = 1;
        private BulletRigdbody2D bulletRigdbody2D;

        private void Awake() {
            bulletRigdbody2D = GetComponent<BulletRigdbody2D>();
        }

        private void FixedUpdate() {
            bulletRigdbody2D.SetVelocity(transform.right * moveSpeed);
        }
    }
}