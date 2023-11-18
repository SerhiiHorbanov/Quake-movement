using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementJump : MonoBehaviour
{
    [SerializeField] PlayerGroundCheck groundCheck;
    [SerializeField] Rigidbody rigidBody;

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
