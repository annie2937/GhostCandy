using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0, 5, -10);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float newX = player.position.x + offset.x;
        float newY = transform.position.y;
        float newZ = player.position.z + offset.z;

        transform.position = new Vector3(newX, newY, newZ);
    }
}
