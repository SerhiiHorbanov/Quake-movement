using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash
{
    public float currentDashAcceleration { get; private set; }
    public float dashAccelerationIncrease { get; private set; }
    public int dashFramesLeft { get; private set; }
    public Vector3 dashDirection { get; private set; }
    public DashAccelerationChangeTypes type { get; private set; }
    public DashAccelerationChangeTypes endActionType { get; private set; }
    public float endActionValue { get; private set; }

    public bool IsEnded
        => dashFramesLeft <= 0;

    public Dash(float currentDashAcceleration, float dashAccelerationIncrease, int dashFramesLeft, Vector3 dashDirection, DashAccelerationChangeTypes type, DashAccelerationChangeTypes endActionType, float endActionValue)
    {
        this.currentDashAcceleration = currentDashAcceleration;
        this.dashAccelerationIncrease = dashAccelerationIncrease;
        this.dashFramesLeft = dashFramesLeft;
        this.dashDirection = dashDirection;
        this.type = type;
        this.endActionType = endActionType;
        this.endActionValue = endActionValue;
    }

    public void ApplyDash(Rigidbody rigidBody)
    {
        switch (type)//i decided to use switch because i may add more dash acceleration change types and because the argument is enum
        {
            case DashAccelerationChangeTypes.exponential:
                currentDashAcceleration *= dashAccelerationIncrease;
                break;
            case DashAccelerationChangeTypes.linear:
                currentDashAcceleration += dashAccelerationIncrease;
                break;
        }

        Vector2 HorizontalVelocity = new Vector2(rigidBody.velocity.x, rigidBody.velocity.z);
        Vector2 HorizontalDashDirection = new Vector2(dashDirection.x, dashDirection.z);

        if (Vector2.Dot(HorizontalVelocity, HorizontalDashDirection) < 0)
            rigidBody.velocity = new Vector3(0, rigidBody.velocity.y, 0);

        rigidBody.velocity += (dashDirection * currentDashAcceleration);

        dashFramesLeft -= 1;
        return;
    }

    public void EndDashAction(Rigidbody rigidBody)
    {
        Vector3 vector = dashDirection * endActionValue;
        switch (endActionType)
        {
            case DashAccelerationChangeTypes.constant:
                rigidBody.velocity = vector;
                break;
            case DashAccelerationChangeTypes.linear:
                rigidBody.velocity += vector;
                break;
            case DashAccelerationChangeTypes.exponential:
                rigidBody.velocity = new Vector3(rigidBody.velocity.x * endActionValue, rigidBody.velocity.y, rigidBody.velocity.z * endActionValue);
                break;

        }
    }
}
