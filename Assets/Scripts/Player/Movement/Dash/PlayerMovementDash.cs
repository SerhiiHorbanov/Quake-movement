using System.Collections.Generic;
using UnityEngine;

namespace Player.Movement.Dash
{
    public class PlayerMovementDash : MonoBehaviour
    {
        [Tooltip("how many FixedUpdate frames common dashes will last")]
        [SerializeField] private int dashFramesCount;

        [Tooltip("acceleration set on the start of a common dash")]
        [SerializeField] private float startingDashAcceleration;

        [Header("acceleration increase")]

        [Tooltip("how much will acceleration increase. dashAccelerationIncrease will be multiplied/added to startingDashAcceleration every FixedUpdate frame. what exactly it will do depends on commonDashType value")]
        [SerializeField] private float dashAccelerationIncrease;

        [Tooltip("decides how dashAccelerationIncrease will affect currentDashAcceleration")]
        [SerializeField] private DashAccelerationChangeTypes commonDashType;

        [Header("end action")]

        [Tooltip("endActionValue is the float by which horizontal velocity will be multiplied or how long will be the vector added to velocity. what exactly it will do depends on commonDashEndActionType")]
        [SerializeField] private float endActionValue;

        [Tooltip("decides how endActionValue will affect velocity")]
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
                    currentDashes.RemoveAt(i);
                    i--;
                }

                else
                    currentDashes[i].ApplyDash(rigidBody);
            }
        }

        /*public void StartCommonDash(InputAction.CallbackContext context)
            => StartCommonDash(context.ReadValue<Vector2>());*/

        public void TryStartCommonDash()
        {
            Vector3 lookDirection2D = new Vector3(transform.forward.x, 0, transform.forward.z);
            Velocity = new Vector3(0, 0, 0);
            StartDash(new Dash(startingDashAcceleration, dashAccelerationIncrease, dashFramesCount, lookDirection2D, commonDashType, commonDashEndActionType, endActionValue));
            Debug.Log("started dash");
        }

        private void StartDash(Dash dash)
        {
            currentDashes.Add(dash);
        }
    }
}