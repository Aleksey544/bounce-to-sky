//Скрипт движения и управления игроком
using UnityEngine;
using DG.Tweening;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public Rigidbody player;
    private Vector3 playerPosition;
    public float speed;
    public float jumpPowerUp;
    public float jumpPowerForward;
    public float doubleJumpPowerUpCoefficient;
    public float doubleJumpForwardCoefficient;
    public float speedCoefficient;
    public int platformGenerationCounter;
    private string movementButton;
    public int targetFPS = 60;
    public int Score = 0;
    public int CurrentCoins = 0;
    public TMP_Text ScoreText;
    public TMP_Text CoinsText;
    public GameManager gameManager;
    public AudioManager audioManager;
    private bool isPlayerDied = false;

    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFPS;
    }

    private void Start()
    {
        playerPosition.y = transform.position.y;
        audioManager = AudioManager.Instantiate;
    }

    void FixedUpdate()
    {
        GeneratePlatforms();
        GetInput();
        PlayerDied();
    }

    private void PlayerDied()
    {
        if (transform.position.y < Score - 3 && !isPlayerDied)
        {
            isPlayerDied = true;
            audioManager.PlayerDiedSoundPlay();
        }

        if (transform.position.y < Score - 20)
        {
            SettingsAssistant.Coins += CurrentCoins;

            if (Score > SettingsAssistant.BestScore)
                SettingsAssistant.BestScore = Score;

            gameManager.GameOver(Score, CurrentCoins);
        }
    }

    private void GeneratePlatforms()
    {
        if (Mathf.FloorToInt(transform.position.y) > Mathf.FloorToInt(playerPosition.y + platformGenerationCounter))
        {
            PlatformGenerator platformGenerator = FindObjectOfType<PlatformGenerator>();

            if (platformGenerator != null)
            {
                platformGenerator.GeneratePlatforms(platformGenerationCounter + 1);
                playerPosition.y = transform.position.y;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Platform")
        {
            player.AddForce(0, jumpPowerUp * Time.deltaTime, jumpPowerForward * Time.deltaTime, ForceMode.Impulse);
            audioManager.PlayerJumpSoundPlay("Platform");
        }
        else if (collision.collider.tag == "DoubleJumpPlatform")
        {
            player.AddForce(0, doubleJumpPowerUpCoefficient * jumpPowerUp * Time.deltaTime,
                doubleJumpForwardCoefficient * jumpPowerForward * Time.deltaTime, ForceMode.Impulse);

            audioManager.PlayerJumpSoundPlay("DoubleJumpPlatform");
        }

        PlayerAnimation();
        AddScore();
    }

    private void AddScore()
    {
        Score = Mathf.FloorToInt(transform.position.y);
        ScoreText.text = Score.ToString();
    }

    public void AddCoins()
    {
        CurrentCoins++;
        CoinsText.text = CurrentCoins.ToString();
        audioManager.CoinCollectedSoundPlay();
    }

    public void SetMovementButton(string pressedButton)
    {
        movementButton = pressedButton;
    }

    private void GetInput()
    {
        if (Input.GetKey("d") || movementButton == "Right")
            OnRightButtonPressed();

        if (Input.GetKey("a") || movementButton == "Left")
            OnLeftButtonPressed();

        if (Input.GetKey("w") || movementButton == "Forward")
            OnForwardButtonPressed();

        if (Input.GetKey("s") || movementButton == "Back")
            OnBackButtonPressed();
    }

    private void OnRightButtonPressed()
    {
        player.AddForce(speed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }

    private void OnLeftButtonPressed()
    {
        player.AddForce(-speed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }

    private void OnForwardButtonPressed()
    {
        player.AddForce(0, 0, speedCoefficient * speed * Time.deltaTime, ForceMode.VelocityChange);
    }

    private void OnBackButtonPressed()
    {
        player.AddForce(0, 0, speedCoefficient * -speed * Time.deltaTime, ForceMode.VelocityChange);
    }

    private void PlayerAnimation()
    {
        transform.DORewind();
        transform.DOShakeScale(.5f, .5f, 3, 10);
    }
}
