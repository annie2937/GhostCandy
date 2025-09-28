using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI candyCountText;
    private int candyCount = 0;

    public void AddCandy()
    {
        candyCount++;
        UpdateCandyCountText();
    }

    void UpdateCandyCountText()
    {
        candyCountText.text = ": " + candyCount + " / 30";
    }
}
