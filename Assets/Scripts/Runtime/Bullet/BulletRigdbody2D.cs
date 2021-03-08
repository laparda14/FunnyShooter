using UnityEngine;

namespace FunnyShooter.Runtime {
    [RequireComponent(typeof(Rigidbody2D))]
    public class BulletRigdbody2D : MonoBehaviour {
        private new Rigidbody2D rigidbody2D;
        [SerializeField]
        private Vector2 velocity;

        private void Awake() {
            rigidbody2D = GetComponent<Rigidbody2D>();
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
    }
}