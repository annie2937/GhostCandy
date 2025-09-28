using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeLimit = 150f;
    public TMP_Text timerText;
    public GameObject gameOverPanel;

    private float timeRemaining;
    private bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = timeLimit;
        gameOverPanel.SetActive(false);
        UpdateTimerText();
    }

    // Update is called once per frame
    void Update()
    {

        if (isGameOver)
            return;

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerText();
        }
        else
        {
            GameOver();
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = "Time: " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void GameOver()
    {
        isGameOver = true;
        gameOverPanel.SetActive(true);
        Debug.Log("Game Over!");
        timerText.gameObject.SetActive(false);
    }

    public void GoToHome()
    {
        SceneManager.LoadScene("Stage1");
    }

    public void GoBackToStage()
    {
        SceneManager.LoadScene("Stage2");
        Debug.Log("Restart the Game!");
    }


}
