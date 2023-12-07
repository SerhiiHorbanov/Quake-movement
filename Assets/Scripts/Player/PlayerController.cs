using UnityEngine;
using UnityEngine.InputSystem;
using Player.Movement;
using Player.Movement.Dash;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] Jump jump;
        [SerializeField] Walk walk;
        [SerializeField] DashManager dash;
        [SerializeField] PlayerCamera look;

        Vector2 walkDirection = Vector2.zero;
        public void ChangeWalkDirection(InputAction.CallbackContext context)
        {
            walkDirection = context.ReadValue<Vector2>();
        }

        private void FixedUpdate()
        {
            walk.SetRelativeWalkDirection(walkDirection);
        }

        public void TryStartDash(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Started)
                dash.TryStartCommonDash();
        }

        public void TryStartJump(InputAction.CallbackContext context)
        {
            jump.isJumping = context.phase.IsInProgress();
        }

        public void RotateLook(InputAction.CallbackContext context)
        {
            look.RotateLook(context.ReadValue<Vector2>());
        }
    }
}
