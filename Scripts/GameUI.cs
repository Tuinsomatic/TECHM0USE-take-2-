using UnityEngine;
using System.Collections;

public class GameUI : MonoBehaviour
{
    private int health;
    private int score;
    private string gameInfo = "";

    private Rect boxRectangle = new Rect(10, 10, 300, 35);

    void OnEnable()
    {
        PlayerBehaviour.OnUpdateHealth += HandleonUpdateHealth;
        AddScore.OnSendScore += HandleonSendScore;
    }

    void OnDisable()
    {
        PlayerBehaviour.OnUpdateHealth -= HandleonUpdateHealth;
        AddScore.OnSendScore -= HandleonSendScore;
    }

    void Start()
    {
        UpdateUI();
    }

    void HandleonUpdateHealth(int newHealth)
    {
        health = newHealth;
        UpdateUI();
    }

    void HandleonSendScore(int theScore)
    {
        score += theScore;
        UpdateUI();
    }

    void UpdateUI()
    {
        gameInfo = "Score: " + score.ToString() + "\nHealth: " + health.ToString();
    }

    void OnGUI()
    {
        GUI.Box(boxRectangle, gameInfo);
    }
}