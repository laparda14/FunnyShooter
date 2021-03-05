using UnityEngine;

namespace FunnyShooter.Runtime {
    [RequireComponent(typeof(Collider2D))]
    public class PlayerCollider2D : UnetBehaviour {
        private new Collider2D collider2D;

        public Bounds Bounds {
            get { return collider2D.bounds; }
        }

        private void Awake() {
            collider2D = GetComponent<Collider2D>();
        }
    }
}