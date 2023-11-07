using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundCheck : MonoBehaviour
{
    public bool isOnGround { get; private set; } = false;

    private void OnTriggerEnter()
        => isOnGround = true;

    private void OnTriggerExit()
        => isOnGround = false;
}
