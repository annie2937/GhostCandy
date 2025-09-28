using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float fallMultiplier = 2.5f;
    private Rigidbody rb;
    private bool isGrounded;
    private int jumpCount = 0;

    public SpriteRenderer spriteRenderer;
    public Sprite originalSprite;
    public Sprite gameOverSprite;
    public GameObject gameOverPanel;
    public Sprite squishedSprite;

    private bool isGameOver;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalSprite = spriteRenderer.sprite;
        gameOverPanel.SetActive(false);
        isGameOver = false;
    }

    void Update()
    {
        if (isGameOver) return;

        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(moveInput * moveSpeed, rb.velocity.y, 0);

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 1)
        {
            Jump();
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        jumpCount++;
        isGrounded = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground") || collision.collider.CompareTag("block"))
        {
            isGrounded = true;
            jumpCount = 0;
        }

        if (collision.collider.CompareTag("enemy"))
        {
            if (IsBottomCollision(collision))
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpForce * 0.5f, rb.velocity.z); 
                StartCoroutine(SquishEnemyAndChangeCharacterSprite(collision.gameObject));
                Debug.Log("Stepped on enemy! Jumped slightly.");
            }
            else if (IsSideOrTopCollision(collision))
            {
                gameOverPanel.SetActive(true);
                isGameOver = true;
                StartCoroutine(ChangeSpriteAndShake());
                Debug.Log("Game Over! Character sprite changed.");
            }
        }

        if (collision.collider.CompareTag("greenWater"))
        {
            gameOverPanel.SetActive(true);
            isGameOver = true;
            StartCoroutine(ChangeSpriteAndShake());
            Debug.Log("Game Over! Fell into green water.");
        }
    }

    private bool IsSideOrTopCollision(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if (contact.normal.y <= 0.5f)
            {
                return true;
            }
        }
        return false;
    }

    private bool IsBottomCollision(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if (contact.normal.y > 0.5f)
            {
                return true;
            }
        }
        return false;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Ground") || collision.collider.CompareTag("block"))
        {
            isGrounded = false;
        }
    }

    private IEnumerator ChangeSpriteAndShake()
    {
        spriteRenderer.sprite = gameOverSprite;

        Vector3 originalPosition = transform.localPosition;
        float shakeDuration = 0.5f;
        float shakeMagnitude = 0.1f;

        for (float t = 0; t < shakeDuration; t += Time.deltaTime)
        {
            float xOffset = Random.Range(-shakeMagnitude, shakeMagnitude);
            float yOffset = Random.Range(-shakeMagnitude, shakeMagnitude);
            transform.localPosition = originalPosition + new Vector3(xOffset, yOffset, 0);
            yield return null;
        }

        transform.localPosition = originalPosition;

        gameOverPanel.SetActive(true);
        Debug.Log("Game Over Panel activated!");
    }

    private IEnumerator SquishEnemyAndChangeCharacterSprite(GameObject enemy)
    {
        Vector3 originalEnemyScale = enemy.transform.localScale;
        spriteRenderer.sprite = squishedSprite;

        float scaleDuration = 0.2f;
        float elapsed = 0f;

        while (elapsed < scaleDuration)
        {
            if (enemy == null)
            {
                yield break;
            }

            float t = elapsed / scaleDuration;

            float newScale = Mathf.Lerp(originalEnemyScale.x, 0, t);
            enemy.transform.localScale = new Vector3(newScale, newScale, originalEnemyScale.z);

            elapsed += Time.deltaTime;
            yield return null;
        }

        if (enemy != null)
        {
            Destroy(enemy); 
        }

        spriteRenderer.sprite = originalSprite;
    }
}
