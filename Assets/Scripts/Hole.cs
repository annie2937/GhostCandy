using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Sprite newSprite;
    private SpriteRenderer spriteRenderer;
    public float jumpForce = 5f;
    private Rigidbody rb;
    private bool isJumping = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("greenWater"))
        {
            ChangeSprite();
            Jump(); 
        }
    }

    void ChangeSprite()
    {
        if (newSprite != null && spriteRenderer != null)
        {
            spriteRenderer.sprite = newSprite;
        }
    }

    void Jump()
    {
        if (!isJumping) 
        {
            isJumping = true; 
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            Invoke("ShowGameOver", 0.5f); 
        }
    }

    void ShowGameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}
