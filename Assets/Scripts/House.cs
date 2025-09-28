using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class House : MonoBehaviour
{
    public string targetTag = "Player";
    public Sprite newSprite;
    public float delayBeforeSceneChange = 2f;

    private bool gameEnded = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag) && !gameEnded)
        {
            SpriteRenderer spriteRenderer = other.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null && newSprite != null)
            {
                spriteRenderer.sprite = newSprite;
            }

            Debug.Log("End the Game :)");

            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.enabled = false;
            }

            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.isKinematic = true;
            }

            gameEnded = true;

            StartCoroutine(ChangeSceneAfterDelay());
        }
    }

    private IEnumerator ChangeSceneAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeSceneChange);

        SceneManager.LoadScene("Stage3");
    }
}
