using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerMovement : MonoBehaviour
{
    public GameObject player;
    public Vector2 cameraShift;
    public bool followYPosition;

    private void Update()
    {
        Vector3 newPos = new Vector3(
            player.transform.position.x + cameraShift.x,
            Convert.ToInt32(followYPosition) * player.transform.position.y + cameraShift.y,
            transform.position.z);

        transform.position = newPos;
    }
}
