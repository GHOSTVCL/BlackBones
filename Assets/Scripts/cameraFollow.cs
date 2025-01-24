using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0, 5, -10);
    public float smoothspeed = 0.125f;
    private void Update()
    {
        Vector3 followposition = player.position + offset;
        Vector3 smootheredPosition = Vector3.Lerp(transform.position, followposition, smoothspeed);
        transform.position = smootheredPosition;
    }
}
