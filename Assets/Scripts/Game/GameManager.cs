using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TMP_Text GameOverScoreText;
    public TMP_Text GameOverCoinsText;
    public GameObject GamePausedPanel;
    public GameObject GameOverPanel;
    public GameObject ControlButtonsPanel;
    public GameObject TopPanel;
    public GameObject Player;

    public void Resume()
    {
        GamePausedPanel.SetActive(false);
        ControlButtonsPanel.SetActive(true);
        Time.timeScale = 1.0f;
    }

    public void Pause()
    {
        GamePausedPanel.SetActive(true);
        ControlButtonsPanel.SetActive(false);
        Time.timeScale = 0.0f;
    }

    public void GameOver(int Score, int CurrentCoins)
    {
        ControlButtonsPanel.SetActive(false);
        TopPanel.SetActive(false);
        Player.SetActive(false);
        GameOverPanel.SetActive(true);
        GameOverScoreText.text = Score.ToString();
        GameOverCoinsText.text = CurrentCoins.ToString();
    }

    public void MenuButtonPressed()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MenuScene");
    }

    public void RestartButtonPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}