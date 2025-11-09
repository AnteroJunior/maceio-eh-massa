using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Image fuelBarFillImage;
    public TMPro.TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;
    private PlayerController player;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        gameOverPanel.SetActive(false);
    }

    void Update()
    {
        TrafficSpawner spawner = FindObjectOfType<TrafficSpawner>();
        if (spawner != null)
        {
            scoreText.text = "SCORE: " + ((int)spawner.score).ToString();
        }

        if (player == null) return;

        float fuelPercent = player.currentFuel / player.maxFuel;
        fuelBarFillImage.fillAmount = fuelPercent;
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}