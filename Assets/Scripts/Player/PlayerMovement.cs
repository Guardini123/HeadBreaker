using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 speedInDirections;

    private Player player;

    private Rigidbody playerRb;

    private void Start()
    {
        player = this.GetComponent<Player>();

        playerRb = player.rb;
        speedInDirections = player.GetDirection();
    }

    private void FixedUpdate()
    {
        if (player.canMove)
        {
            if (player.canMoveInPlusDirection)
            {
                playerRb.velocity += speedInDirections;
            }
            if (player.canMoveInMinusDirection)
            {
                playerRb.velocity -= speedInDirections;
            }
        }
    }

    public void SetDirection(Vector3 dir)
    {
        speedInDirections = dir;
    }
}
