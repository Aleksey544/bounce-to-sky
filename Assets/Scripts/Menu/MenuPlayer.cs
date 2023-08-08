using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class MenuPlayer : MonoBehaviour
{
    public Rigidbody player;
    public TMP_Text BestScoreText;
    public float jumpPowerUp;
    public int targetFPS = 60;

    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFPS;
    }

    public void Start()
    {
        BestScoreText.text = SettingsAssistant.BestScore.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Platform")
        {
            player.AddForce(0, jumpPowerUp * Time.deltaTime, 0, ForceMode.Impulse);
            PlayerAnimation();
        }
    }

    private void PlayerAnimation()
    {
        transform.DORewind();
        transform.DOShakeScale(.5f, .15f, 3, 10);
    }
}