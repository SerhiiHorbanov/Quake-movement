using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerGroundCheck))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementJump : MonoBehaviour
{
    [SerializeField] PlayerGroundCheck groundCheck;
    [SerializeField] Rigidbody rigidBody;

    [Tooltip("vertical velocity that will be added to player when initiaging jump... i mean just the force of a jump")]
    [SerializeField] float jumpSpeed;

    public bool TryJump()
    {
        if (groundCheck.isOnGround)
            Jump();
        return groundCheck.isOnGround;
    }

    private void Jump()
    {
        Vector3 velocity = rigidBody.velocity;

        rigidBody.velocity = new Vector3(velocity.x, jumpSpeed, velocity.z);
    }
}
