using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public float soundsVolume = 0.35f;
    public float musicVolume = 0.4f;
    public Button musicButton;
    public Button soundsButton;
    public Sprite musicOnImage;
    public Sprite musicOffImage;
  
    [SerializeField] private AudioClip[] screamingSounds;
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private AudioSource jumpAndButtonSounds;
    [SerializeField] private AudioSource coinAndDieSounds;

    private void Start()
    {
        ChangeMusicVolume();
        ChangeSoundsVolume();
    }

    public void PlayerJumpSoundPlay(string PlatformTag)
    {
        if (PlatformTag == "Platform")
        {
            jumpAndButtonSounds.pitch = 1f;
        }
        else if (PlatformTag == "DoubleJumpPlatform")
        {
            jumpAndButtonSounds.pitch = 1.4f;
        }

        jumpAndButtonSounds.Play();
    }

    public void CoinCollectedSoundPlay()
    {
        coinAndDieSounds.Play();
    }

    public void PlayerDiedSoundPlay()
    {
        if (SettingsAssistant.IsSoundsPlaying)
        {
            coinAndDieSounds.clip = screamingSounds[Random.Range(0, screamingSounds.Length)];
            coinAndDieSounds.volume = 1f;
            coinAndDieSounds.Play();
        }
    }

    private void ChangeMusicVolume()
    {
        if (SettingsAssistant.IsMusicPlaying)
        {
            if (backgroundMusic != null)
                backgroundMusic.volume = musicVolume;

            if (musicButton != null)
                musicButton.image.sprite = musicOnImage;
        }
        else
        {
            if (backgroundMusic != null)
                backgroundMusic.volume = 0f;

            if (musicButton != null)
                musicButton.image.sprite = musicOffImage;
        }
    }

    private void ChangeSoundsVolume()
    {
        if (SettingsAssistant.IsSoundsPlaying)
        {
            if (jumpAndButtonSounds != null)
                jumpAndButtonSounds.volume = soundsVolume;

            if (coinAndDieSounds != null)
                coinAndDieSounds.volume = soundsVolume;

          //  if (soundsButton != null)
            //    soundsButton.image.sprite = soundsOnImage;
        }
        else
        {
            if (jumpAndButtonSounds != null)
                jumpAndButtonSounds.volume = 0f;

            if (coinAndDieSounds != null)
                coinAndDieSounds.volume = 0f;

          //  if (soundsButton != null)
          //      soundsButton.image.sprite = soundsOffImage;
        }
    }

    public void SoundsButtonPressed()
    {
        if (SettingsAssistant.IsSoundsPlaying)
        {
            SettingsAssistant.IsSoundsPlaying = false;
            ChangeSoundsVolume();
        }
        else
        {
            SettingsAssistant.IsSoundsPlaying = true;
            ChangeSoundsVolume();
        }
    }

    public void MusicButtonPressed()
    {
        if (SettingsAssistant.IsMusicPlaying)
        {
            SettingsAssistant.IsMusicPlaying = false;
            ChangeMusicVolume();
        }
        else
        {
            SettingsAssistant.IsMusicPlaying = true;
            ChangeMusicVolume();
        }
    }
}
