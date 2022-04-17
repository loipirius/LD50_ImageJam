using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowJumper : MonoBehaviour
{
    public Transform target;
    public JumperController player;

    private void LateUpdate()
    {
        if (player != null)
        {
            if (player.IsGrounded())
            {
                var yPosition = transform.position.y;
                yPosition += Time.deltaTime;
                Vector3 newY = new Vector3(transform.position.x, yPosition,transform.position.z);
                transform.position = newY;
            }
        }

        if (target != null)
        {
            if (target.position.y > transform.position.y)
            {
                Vector3 newPosition = new Vector3(transform.position.x, target.position.y,transform.position.z);
                transform.position = newPosition;
            }
        }
    }
}
