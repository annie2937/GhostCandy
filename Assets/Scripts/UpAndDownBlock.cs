using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAndDownBlock : MonoBehaviour
{
    public float moveDistance = 2f;
    public float speed = 2f;

    private Vector3 startPosition;
    private float targetY;
    private bool movingUp = true;

    void Start()
    {
        startPosition = transform.position;
        targetY = startPosition.y + moveDistance;
    }

    void Update()
    {
        if (movingUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(startPosition.x, targetY, startPosition.z), speed * Time.deltaTime);

            if (transform.position.y >= targetY)
            {
                movingUp = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);

            if (transform.position.y <= startPosition.y)
            {
                movingUp = true;
            }
        }
    }
}
