using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementDash : MonoBehaviour
{
    [SerializeField] private int dashFramesCount;

    [SerializeField] private float startingDashAcceleration;
    [Header("acceleration increase")]
    [SerializeField] private float dashAccelerationIncrease;
    [SerializeField] private DashAccelerationChangeTypes commonDashType;
    [Header("end action")]
    [SerializeField] private float endActionValue;
    [SerializeField] private DashAccelerationChangeTypes commonDashEndActionType;

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
                currentDashes[i].EndDashAction(rigidBody);
                Debug.Log($"removing dash at index{i}");
                currentDashes.RemoveAt(i);
                i--;
            }

            else
            {
                currentDashes[i].ApplyDash(rigidBody);
                Debug.Log($"applyed dash with index {i}");
            }
        }
    }

    public void TryStartDash(Vector3 direction)
    {
        Velocity = new Vector3(0, 0, 0);
        StartDash(new Dash(startingDashAcceleration, dashAccelerationIncrease, dashFramesCount, direction, commonDashType, commonDashEndActionType, endActionValue));
    }

    private void StartDash(Dash dash)
    {
        currentDashes.Add(dash);
    }
}
