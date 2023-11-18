using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementDash : MonoBehaviour
{
    [SerializeField] private int dashFramesCount;

    [SerializeField] private float dashAccelerationIncrease = 1.1f;
    [SerializeField] private float startingDashAcceleration = 0.1f;

    [SerializeField] Rigidbody rigidBody;

    public List<Dash> currentDashes = new List<Dash>();

    Vector3 Velocity
    {
        get
            => rigidBody.velocity;
        set
            => rigidBody.velocity = value;
    }

    public void FixedUpdate()
    {
        for (int i = 0; i < currentDashes.Count; i++)
        {
            if (currentDashes[i].IsEnded)
            {
                currentDashes.RemoveAt(i);
                i--;
            }

            else
                currentDashes[i].ApplyDash(rigidBody);
        }
    }

    public void TryStartDash2D(Vector2 direction, DashAccelerationChangeTypes dashType)
    {
        StartDash2D(direction, dashType);
    }

    private void StartDash2D(Vector2 direction, DashAccelerationChangeTypes dashType)
    {
        Vector3 direction3D = new Vector3(direction.x, 0, direction.y);

        currentDashes.Add(new Dash(startingDashAcceleration, dashAccelerationIncrease, dashFramesCount, direction3D, dashType));
    }
    
    public void TryStartDash3D(Vector3 direction)
    {

    }

    private void StartDash3D(Vector3 direction)
    {

    }
}
