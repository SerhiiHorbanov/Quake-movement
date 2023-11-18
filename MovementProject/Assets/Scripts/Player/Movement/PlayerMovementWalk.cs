using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementWalk : MonoBehaviour
{
    [SerializeField] float maxSpeed;
    [SerializeField] float maxAirSpeed;
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

    public void Walk(Vector2 direction)
    {
        if (groundCheck == null)
            return;

        direction.Normalize();

        Vector2 horizontalVelocity = new Vector2(Velocity.x, Velocity.z);

        float speed = Vector2.Dot(horizontalVelocity, direction);//speed in the direction of direction vector

        float currentMaxSpeed = groundCheck.isOnGround ? maxSpeed : maxAirSpeed;

        float additionalSpeed = Mathf.Clamp(currentMaxSpeed - speed, 0, maxAccel);

        Vector3 additionalVelocity = new Vector3(direction.x * additionalSpeed, 0, direction.y * additionalSpeed);

        Velocity += additionalVelocity;
    }

    private void FixedUpdate()
    {
        if (groundCheck.isOnGround)
            Velocity = new Vector3(Velocity.x * frictionMultiplier, Velocity.y, Velocity.z * frictionMultiplier);
    }
}
