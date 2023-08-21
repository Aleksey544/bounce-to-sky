using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameButtons : MonoBehaviour
{
    public TMP_Text GameOverScoreText;
    public TMP_Text GameOverCoinsText;
    public GameObject GamePausedPanel;
    public GameObject GameOverPanel;
    public GameObject ControlButtonsPanel;
    public GameObject Joystick;
    public GameObject TopPanel;
    public GameObject Player;

    public void ContinueButtonPressed()
    {
        GamePausedPanel.SetActive(false);
        ControlButtonsPanel.SetActive(true);
        Time.timeScale = 1.0f;
    }

    public void PauseButtonPressed()
    {
        GamePausedPanel.SetActive(true);
        ControlButtonsPanel.SetActive(false);
        Time.timeScale = 0.0f;
    }

    public void MenuButtonPressed()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartButtonPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver(int Score, int CurrentCoins)
    {
        ControlButtonsPanel.SetActive(false);
        //Joystick.SetActive(false);
        TopPanel.SetActive(false);
        Player.SetActive(false);
        GameOverPanel.SetActive(true);
        GameOverScoreText.text = Score.ToString();
        GameOverCoinsText.text = CurrentCoins.ToString();
    }

    public void ContinueGame()
    {
        ControlButtonsPanel.SetActive(true);
        //Joystick.SetActive(true);
        TopPanel.SetActive(true);
        Player.SetActive(true);
        GameOverPanel.SetActive(false);
    }
}