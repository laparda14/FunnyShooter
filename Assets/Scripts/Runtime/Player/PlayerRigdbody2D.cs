using UnityEngine;

namespace FunnyShooter.Runtime {
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerRigdbody2D : UnetBehaviour {
        private new Rigidbody2D rigidbody2D;
        [SerializeField]
        private Vector2 velocity;

        private bool isVelocityXChange;
        private bool isVelocityYChange;

        private void Awake() {
            rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update() {
            if (!Mathf.Approximately(rigidbody2D.velocity.x, 0f)) {
                Utility.Event.Fire(GameEventId.OnVelocityXChange, rigidbody2D.velocity.x);
                isVelocityXChange = true;
            } else if (isVelocityXChange) {
                Utility.Event.Fire(GameEventId.OnVelocityXChange, 0f);
                isVelocityXChange = false;
            }

            if (!Mathf.Approximately(rigidbody2D.velocity.y, 0f)) {
                Utility.Event.Fire(GameEventId.OnVelocityYChange, rigidbody2D.velocity.y);
                isVelocityYChange = true;
            } else if (isVelocityYChange) {
                Utility.Event.Fire(GameEventId.OnVelocityYChange, 0f);
                isVelocityYChange = false;
            }
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