using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public float soundsVolume = 0.35f;
    public float musicVolume = 0.4f;

    [SerializeField] private AudioClip gameMusic;
    [SerializeField] private AudioClip mainMenuMusic;
    [SerializeField] private AudioClip[] screamingSounds;
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private AudioSource jumpAndSounds;
    [SerializeField] private AudioSource coinAndDieSounds;

    private static AudioManager instantiate;

    public static AudioManager Ins
    {
        get
        {
            if (instantiate == null)
            {
                AudioManager resource = Resources.Load<AudioManager>("Managers/AudioManager");
                instantiate = Instantiate(resource);
            }

            return instantiate;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        ChangeMusicVolume();
        ChangeSoundsVolume();
        PlayMenuMusic();
    }

    public void PlayMenuMusic() 
    { 
        backgroundMusic.clip = mainMenuMusic;
        backgroundMusic.Play(); 
    
    }

    public void PlayGameMusic() 
    { 
        backgroundMusic.clip = gameMusic;
        backgroundMusic.Play(); 
    }

    public void PlayerJumpSoundPlay(string PlatformTag)
    {
        if (PlatformTag == "Platform")
        {
            jumpAndSounds.pitch = 1f;
        }
        else if (PlatformTag == "DoubleJumpPlatform")
        {
            jumpAndSounds.pitch = 1.4f;
        }

        jumpAndSounds.Play();
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
        }
        else
        {
            if (backgroundMusic != null)
                backgroundMusic.volume = 0f;
        }
    }

    private void ChangeSoundsVolume()
    {
        if (SettingsAssistant.IsSoundsPlaying)
        {
            if (jumpAndSounds != null)
                jumpAndSounds.volume = soundsVolume;

            if (coinAndDieSounds != null)
                coinAndDieSounds.volume = soundsVolume;

            //  if (soundsButton != null)
            //    soundsButton.image.sprite = soundsOnImage;
        }
        else
        {
            if (jumpAndSounds != null)
                jumpAndSounds.volume = 0f;

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
