using System.Collections;
using UnityEngine;

public class LeftAndRight : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float moveDistance = 8f;
    private Vector3 originalPosition;
    private bool movingRight = true;

    void Start()
    {
        originalPosition = transform.position;
        StartCoroutine(MoveCoroutine());
    }

    private IEnumerator MoveCoroutine()
    {
        while (true)
        {
            if (movingRight)
            {
                for (float t = 0; t < moveDistance / moveSpeed; t += Time.deltaTime)
                {
                    transform.position = new Vector3(originalPosition.x + t * moveSpeed, originalPosition.y, originalPosition.z);
                    yield return null;
                }
                movingRight = false;
            }

            else
            {
                for (float t = 0; t < moveDistance / moveSpeed; t += Time.deltaTime)
                {
                    transform.position = new Vector3(originalPosition.x + moveDistance - t * moveSpeed, originalPosition.y, originalPosition.z);
                    yield return null;
                }
                movingRight = true;
            }
        }
    }
}
