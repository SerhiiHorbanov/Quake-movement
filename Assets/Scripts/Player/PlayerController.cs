using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerMovementJump jump;
    [SerializeField] PlayerMovementWalk walk;
    [SerializeField] PlayerMovementDash dash;

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            jump.TryJump();
        }

        Vector2 walkDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        walkDirection = Quaternion.AngleAxis(transform.rotation.eulerAngles.y, Vector3.back) * walkDirection;

        Vector3 walkDirection3D = new Vector3(walkDirection.x, 0, walkDirection.y);

        if (walkDirection.magnitude != 0)
        {
            walk.walkDirection = walkDirection;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Vector3 LookDirection2D = new Vector3(transform.forward.x, 0, transform.forward.z);
            dash.TryStartDash(walkDirection.magnitude > 0.1 ? walkDirection3D : LookDirection2D);
        }
    }
}
