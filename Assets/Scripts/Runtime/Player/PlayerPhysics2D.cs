using UnityEngine;

namespace FunnyShooter.Runtime {
    [RequireComponent(typeof(PlayerCollider2D))]
    public class PlayerPhysics2D : UnetBehaviour {
        private const float minCheckDistance = 0.1f;
        private bool isOnGroundChange;
        private PlayerCollider2D playerCollider2D;

        public bool IsGround {
            get { return !isOnGroundChange; }
        }

        //public bool IsForwardWall {
        //    get {
        //        Vector2 point = playerCollider2D.Bounds.center;
        //        Vector2 size = playerCollider2D.Bounds.size;
        //        point.x += (playerCollider2D.Bounds.size.x + minCheckDistance) / 2;
        //        point.y += minCheckDistance;
        //        size.x = minCheckDistance;
        //        return Physics2D.OverlapBox(point, size, 0, 1 << LayerMask.NameToLayer(LayerKey.Ground));
        //    }
        //}


        private void Awake() {
            playerCollider2D = GetComponent<PlayerCollider2D>();
        }

        private void Update() {
            CheckIsGround();
        }

        private void CheckIsGround() {
            Vector2 point = playerCollider2D.Bounds.center;
            Vector2 size = playerCollider2D.Bounds.size;
            point.y -= (playerCollider2D.Bounds.size.y + minCheckDistance) / 2; 
            size.y = minCheckDistance;
            size.x -= minCheckDistance;
            bool isGround = Physics2D.OverlapBox(point, size, 0, 1 << LayerMask.NameToLayer(LayerKey.Ground));
            if (!isGround) {
                Utility.Event.Fire(GameEventId.OnGroundChange, isGround);
                isOnGroundChange = true;
            } else if(isOnGroundChange) {
                Utility.Event.Fire(GameEventId.OnGroundChange, true);
                isOnGroundChange = false;
            }
        }
    }
}