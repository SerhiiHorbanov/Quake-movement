using UnityEngine;

namespace Player.Movement
{
    [RequireComponent(typeof(GroundCheck))]
    [RequireComponent(typeof(Rigidbody))]
    public class Jump : MonoBehaviour
    {
        [SerializeField] GroundCheck groundCheck;
        [SerializeField] Rigidbody rigidBody;

        [Tooltip("vertical velocity that will be added to player when initiating jump... i mean just the force of a jump")]
        [SerializeField] float jumpSpeed;

        public bool isJumping = false;

        private void Update()
        {
            if (isJumping)
                TryStartJump();
        }

        public void TryStartJump()
        {
            if (groundCheck.isOnGround)
                StartJump();
        }

        private void StartJump()
        {
            Vector3 velocity = rigidBody.velocity;

            rigidBody.velocity = new Vector3(velocity.x, jumpSpeed, velocity.z);
        }
    }
}
