using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerMovementJump jump;
    [SerializeField] PlayerMovementWalk walk;
    [SerializeField] PlayerMovementDash dash;
    [SerializeField] DashAccelerationChangeTypes type;

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            jump.TryJump();
        }

        Vector2 walkDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        walkDirection = Quaternion.AngleAxis(transform.rotation.eulerAngles.y, Vector3.back) * walkDirection;

        if (walkDirection.magnitude != 0)
        {
            walk.Walk(walkDirection);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            dash.TryStartDash2D(walkDirection.magnitude > 0.1? walkDirection : new Vector2(transform.forward.x, transform.forward.z), type);
        }
    }
}
