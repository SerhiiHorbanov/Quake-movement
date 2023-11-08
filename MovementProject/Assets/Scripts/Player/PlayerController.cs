using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerMovementJump jump;

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            jump.TryJump();
        }
    }
}
