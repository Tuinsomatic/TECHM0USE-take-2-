using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayScore : MonoBehaviour {

    public int score = 0;
    public string text = "";
    private Rect boxRectangle = new Rect(0, -40, 300, 35);

    void OnEnable()
    {
        AddScore.OnSendScore += HandleonSendScore;
    }

    void OnDisable()
    {
        AddScore.OnSendScore -= HandleonSendScore;
    }

    void HandleonSendScore(int theScore)
    {
        score += theScore;
        UpdateUI();
    }

    void UpdateUI()
    {
        text = "Score: " + score.ToString();
    }

    void OnGUI()
    {
        GUI.Box(boxRectangle, text);
    }
}
