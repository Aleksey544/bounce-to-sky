//Скрипт движения и управления игроком
using UnityEngine;
using DG.Tweening;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public Rigidbody player;
    private Vector3 playerPosition;
    private Transform currentPlatformPosition;
    public float speed = 10;
    public float jumpPowerUp = 370;
    public float jumpPowerForward = 74;
    public float doubleJumpPowerUpCoefficient = 1.5f;
    public float doubleJumpForwardCoefficient = 1.3f;
    public float speedCoefficient = 0.7f;
    private string movementButton;
    public int targetFPS = 60;
    public int Score = 0;
    public int CurrentCoins = 0;
    public TMP_Text ScoreText;
    public TMP_Text CoinsText;
    public GameButtons gameButtons;
    private AudioManager audioManager;
    public LevelGenerator levelGenerator;
    public int levelGenerationCounter;
    private bool isPlayerDied = false;

    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFPS;
    }

    private void Start()
    {
        playerPosition.y = transform.position.y;
        audioManager = AudioManager.Ins;
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

            gameButtons.GameOver(Score, CurrentCoins);
        }
    }

    private void GeneratePlatforms()
    {
        if (Mathf.FloorToInt(transform.position.y) > Mathf.FloorToInt(playerPosition.y + levelGenerationCounter))
        {
            if (levelGenerator != null)
            {
                levelGenerator.GenerateCustomPlatformSublevels(levelGenerationCounter + 1);
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

        currentPlatformPosition = collision.transform;

        PlatformAnimation collidedPlatform = collision.collider.GetComponent<PlatformAnimation>();

        if (collidedPlatform)
        {
            collidedPlatform.PlatformAnimationPush();
        }

        //DOTween.Kill(this);

        //collision.transform.DOScale(new Vector3(1f, 4f, 1f), 0.25f).SetId(this).OnComplete(() =>
        //{
        //    collision.transform.DOScale(new Vector3(1f, 1f, 1f), 0.25f).SetId(this);
        //});

        PlayerAnimation();
        AddScore();
    }

    private void AddScore()
    {
        Score = Mathf.FloorToInt(transform.position.y);
        ScoreText.text = Score.ToString();
        EventManager.DeActivateElement(Score);
    }

    public void AddCoins()
    {
        CurrentCoins++;
        CoinsText.text = CurrentCoins.ToString();
    }

    public void DoubleCoinsForWatchAds()
    {
        SettingsAssistant.Coins += CurrentCoins;
        gameButtons.GameOver(Score, CurrentCoins * 2);
    }

    public void SecondLifeForWatchAds()
    {
        gameButtons.ContinueGame();

        GetComponent<LevelGenerator>().GenerateOnePlatform(new Vector3(-10.5f,
            currentPlatformPosition.position.y, currentPlatformPosition.position.z), 4);

        player.velocity = Vector3.zero;

        transform.position = new Vector3(-10.5f,
            currentPlatformPosition.position.y + 1f, currentPlatformPosition.position.z);
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
        transform.DOShakeScale(.5f, .3f, 3, 10);
    }
}
