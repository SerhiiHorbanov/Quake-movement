using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementWalk : MonoBehaviour
{
    [Header("speeds")]

    [Tooltip("max speed on ground. for better understanding check code")]
    [SerializeField] float maxSpeed;

    [Tooltip("max speed in air. for better understanding check code")]
    [SerializeField] float maxAirSpeed;

    [Header("other")]

    [Tooltip("max change of speed that can be applied to velocity per FixedUpdate frame")]
    [SerializeField] float maxAccel;

    [Tooltip("player horizontal velocity multiplies by frictionMultiplier every FixedUpdate frame when groundCheck.isOnGround is true")]
    [SerializeField] float frictionMultiplier;

    [SerializeField] Rigidbody rigidBody;
    [SerializeField] PlayerGroundCheck groundCheck;

    public Vector2 walkDirection;


    Vector3 Velocity
    { 
        get 
            => rigidBody.velocity;
        set
            => rigidBody.velocity = value;
    }

    private void UpdateWalking(Vector2 direction)
    {
        direction.Normalize();

        Vector2 horizontalVelocity = new Vector2(Velocity.x, Velocity.z);

        float speed = Vector2.Dot(horizontalVelocity, direction);//speed in the direction of direction vector

        float currentMaxSpeed = groundCheck.isOnGround ? maxSpeed : maxAirSpeed;

        float additionalSpeed = Mathf.Clamp(currentMaxSpeed - speed, 0, maxAccel);

        Vector3 additionalVelocity = new Vector3(direction.x * additionalSpeed, 0, direction.y * additionalSpeed);

        Velocity += additionalVelocity;
    }

    private void UpdateFriction()
    {
        if (walkDirection.magnitude > 0.01)
        {
            Vector3 lerpingToVector = new Vector3(walkDirection.x, 0, walkDirection.y) * maxSpeed;
            Velocity = Vector3.Lerp(Velocity, lerpingToVector, frictionMultiplier);
            return;
        }
        Velocity = new Vector3(Velocity.x * frictionMultiplier, Velocity.y, Velocity.z * frictionMultiplier);
    }

    private void FixedUpdate()
    {
        if (groundCheck.isOnGround)
            UpdateFriction();

        UpdateWalking(walkDirection);

        walkDirection = Vector2.zero;
    }
}
