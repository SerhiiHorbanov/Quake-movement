using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundCheck : MonoBehaviour
{
    public bool isOnGround
        => collidingWith.Count > 0;

    List<Collider> collidingWith = new List<Collider>();

    private void OnCollisionEnter(Collision collision)
    {
        if (!collidingWith.Contains(collision.collider))
            collidingWith.Add(collision.collider);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collidingWith.Contains(collision.collider))
            collidingWith.Remove(collision.collider);
    }
}
