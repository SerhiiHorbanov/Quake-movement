using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementWalk : MonoBehaviour
{
    [SerializeField] float maxSpeed;
    [SerializeField] float maxAccel;
    [SerializeField] float frictionMultiplier;

    [SerializeField] Rigidbody rigidBody;
    [SerializeField] PlayerGroundCheck groundCheck;

    Vector3 Velocity
    { 
        get 
            => rigidBody.velocity;
        set
            => rigidBody.velocity = value;
    }

    private void WalkOnGround(Vector2 direction)
    {
        direction.Normalize();

        Vector2 horizontalVelocity = new Vector2(Velocity.x, Velocity.z);

        float speed = Vector2.Dot(horizontalVelocity, direction);//speed in the direction of direction vector

        float additionalSpeed = Mathf.Clamp(maxSpeed - speed, 0, maxAccel);

        Vector3 additionalVelocity = new Vector3(direction.x * additionalSpeed, 0, direction.y * additionalSpeed);

        Velocity += additionalVelocity;
    }

    public void Walk(Vector2 direction)
    {
        if (groundCheck == null)
            return;

        if(groundCheck.isOnGround)
            WalkOnGround(direction);
    }

    private void FixedUpdate()
    {
        if (groundCheck.isOnGround)
            Velocity = new Vector3(rigidBody.velocity.x * frictionMultiplier, rigidBody.velocity.y, rigidBody.velocity.z * frictionMultiplier);
    }
}
