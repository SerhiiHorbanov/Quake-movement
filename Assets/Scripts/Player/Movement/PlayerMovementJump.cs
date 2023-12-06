using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerGroundCheck))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementJump : MonoBehaviour
{
    [SerializeField] PlayerGroundCheck groundCheck;
    [SerializeField] Rigidbody rigidBody;

    [Tooltip("vertical velocity that will be added to player when initiating jump... i mean just the force of a jump")]
    [SerializeField] float jumpSpeed;

    public bool isJumping = false;

    private void Update()
    {
        if (isJumping)
            TryJump();
    }

    public void TryJump()
    {
        if (groundCheck.isOnGround)
            Jump();
    }

    private void Jump()
    {
        Vector3 velocity = rigidBody.velocity;

        rigidBody.velocity = new Vector3(velocity.x, jumpSpeed, velocity.z);
    }
}
