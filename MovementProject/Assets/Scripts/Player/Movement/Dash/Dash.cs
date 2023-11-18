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

    public bool IsEnded
        => dashFramesLeft <= 0;

    public Dash(float startDashAcceleration, float dashAccelerationIncrease, int dashFrames, Vector3 dashDirection, DashAccelerationChangeTypes type)
    {
        currentDashAcceleration = startDashAcceleration;
        dashFramesLeft = dashFrames;
        this.dashAccelerationIncrease = dashAccelerationIncrease;
        this.dashDirection = dashDirection;
        this.type = type;
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
        
        Debug.Log(dashDirection * currentDashAcceleration);

        rigidBody.velocity += (dashDirection * currentDashAcceleration);
        dashFramesLeft -= 1;
        return;
    }
}
