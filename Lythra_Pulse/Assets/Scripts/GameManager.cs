using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Text gemasMoradasText;
    public Text gemasRosasText;
    public Text gemasDoradasText;
    public Text scoreText;
    public Text messageText;

    int gemasMoradas = 0;
    int gemasRosas = 0;
    int gemasDoradas = 0;

    int totalMoradas = 6;
    int totalRosas = 6;

    int score = 0;
    bool levelCompleted = false;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void UpdateUI()
    {
        if (gemasMoradasText != null)
            gemasMoradasText.text = "Gemas Moradas: " + gemasMoradas + "/" + totalMoradas;

        if (gemasRosasText != null)
            gemasRosasText.text = "Gemas Rosas: " + gemasRosas + "/" + totalRosas;

        if (gemasDoradasText != null)
            gemasDoradasText.text = "Gemas Doradas: " + gemasDoradas;

        if (scoreText != null)
            scoreText.text = "Puntaje: " + score;
    }

    public void AddGem(string gemType, int points)
    {
        if (levelCompleted) return;

        switch (gemType)
        {
            case "GemaMorada":
                gemasMoradas++;
                break;

            case "GemaRosa":
                gemasRosas++;
                break;

            case "GemaDorada":

                if (gemasMoradas >= totalMoradas && gemasRosas >= totalRosas)
                {
                    gemasDoradas++;
                    Victory();
                }
                else
                {
                    messageText.text = "¡Aún faltan gemas!";
                    return;
                }

                break;
        }

        score += points;
        UpdateUI();
    }

    public void Victory()
    {
        if (levelCompleted) return;
        levelCompleted = true;

        if (messageText != null) 
            messageText.text = "¡Ganaste! ⭐";

        Time.timeScale = 0f;
        Debug.Log("Victoria");
    }

    public void GameOver()
    {
        if (levelCompleted) return;
        levelCompleted = true;

        if (messageText != null) 
            messageText.text = "Game Over ☠️";

        Time.timeScale = 0f;
        Debug.Log("GameOver");
    }
}