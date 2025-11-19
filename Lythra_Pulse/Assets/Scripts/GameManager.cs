using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TMP_Text gemasMoradasText;
    public TMP_Text gemasRosasText;
    public TMP_Text scoreText;
    public TMP_Text messageText;

    public GameObject victoryPanel;
    public GameObject gameOverPanel;

    int gemasMoradas = 0;
    int gemasRosas = 0;

    int totalMoradas = 6;
    int totalRosas = 6;

    int score = 0;
    bool levelCompleted = false;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        Time.timeScale = 1f;
        UpdateUI();

        if (victoryPanel != null) victoryPanel.SetActive(false);
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
        if (messageText != null) messageText.text = "";
    }

    public void AddGem(string gemType, int points)
    {
        if (levelCompleted) return;

        if (gemType == "GemaMorada")
        {
            gemasMoradas++;
        }
        else if (gemType == "GemaRosa")
        {
            gemasRosas++;
        }
        else if (gemType == "GemaDorada")
        {
            // Gema dorada SOLO funciona si ya tienes todas las otras
            if (gemasMoradas >= totalMoradas && gemasRosas >= totalRosas)
            {
                Victory();
            }
            else
            {
                if (messageText != null)
                    messageText.text = "¡Aún faltan gemas moradas o rosas!";
                return;
            }
        }

        score += points;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (gemasMoradasText != null)
            gemasMoradasText.text = "Gemas Moradas: " + gemasMoradas + "/" + totalMoradas;

        if (gemasRosasText != null)
            gemasRosasText.text = "Gemas Rosas: " + gemasRosas + "/" + totalRosas;

        if (scoreText != null)
            scoreText.text = "Puntaje: " + score;
    }

    public void Victory()
    {
        if (levelCompleted) return;

        levelCompleted = true;

        if (messageText != null)
            messageText.text = "¡Ganaste! ⭐";

        if (victoryPanel != null)
            victoryPanel.SetActive(true);

        Time.timeScale = 0f;
    }

    public void GameOver()
    {
        if (levelCompleted) return;

        levelCompleted = true;

        if (messageText != null)
            messageText.text = "Has muerto ☠️";

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        Time.timeScale = 0f;
    }

    public void ReiniciarNivel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void VolverAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
