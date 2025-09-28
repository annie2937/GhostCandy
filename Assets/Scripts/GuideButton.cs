using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuideButton : MonoBehaviour
{
    public void OnGuideButtonClicked()
    {
        SceneManager.LoadScene("Stage1-1");
    }
}
