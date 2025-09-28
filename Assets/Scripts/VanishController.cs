using System.Collections;
using UnityEngine;

public class VanishController : MonoBehaviour
{
    public float shakeDuration = 2f;
    public float shakeMagnitude = 0.1f;
    public float fallSpeed = 5f;

    private Vector3 originalPosition;
    private bool isShaking = false;
    private bool isFalling = false;
    private Rigidbody rb;
    private Collider objectCollider;

    void Start()
    {
        originalPosition = transform.localPosition;

        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
        rb.isKinematic = true;

        objectCollider = GetComponent<Collider>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player") && !isShaking && !isFalling)
        {
            StartCoroutine(ShakeAndFall());
        }
    }

    private IEnumerator ShakeAndFall()
    {
        isShaking = true;

        for (float t = 0; t < shakeDuration; t += Time.deltaTime)
        {
            float xOffset = Random.Range(-shakeMagnitude, shakeMagnitude);
            float yOffset = Random.Range(-shakeMagnitude, shakeMagnitude);
            transform.localPosition = originalPosition + new Vector3(xOffset, yOffset, 0);
            yield return null;
        }

        transform.localPosition = originalPosition;
        isShaking = false;
        isFalling = true;

        rb.isKinematic = false;
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;

        if (objectCollider != null)
        {
            objectCollider.enabled = false;
        }

        while (true)
        {
            yield return new WaitForFixedUpdate();
            rb.velocity = Vector3.down * fallSpeed;
        }
    }
}
