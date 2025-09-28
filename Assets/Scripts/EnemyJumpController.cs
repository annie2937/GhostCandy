using System.Collections;
using UnityEngine;

public class EnemyJumpController : MonoBehaviour
{
    public float jumpHeight = 3f;
    public float jumpSpeed = 2f;
    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;
        StartCoroutine(JumpCoroutine()); 
    }

    private IEnumerator JumpCoroutine()
    {
        while (true)
        {
            for (float t = 0; t < 1; t += Time.deltaTime * jumpSpeed)
            {
                float newY = Mathf.Lerp(originalPosition.y, originalPosition.y + jumpHeight, t);
                transform.position = new Vector3(originalPosition.x, newY, originalPosition.z);
                yield return null;
            }

            for (float t = 0; t < 1; t += Time.deltaTime * jumpSpeed)
            {
                float newY = Mathf.Lerp(originalPosition.y + jumpHeight, originalPosition.y, t);
                transform.position = new Vector3(originalPosition.x, newY, originalPosition.z);
                yield return null;
            }
        }
    }
}
