using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public float soundsVolume = 0.35f;
    public float musicVolume = 0.4f;

    [SerializeField] private AudioClip gameMusic;
    [SerializeField] private AudioClip mainMenuMusic;
    [SerializeField] private AudioClip coinClip;
    [SerializeField] private AudioClip[] screamingClips;
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private AudioSource jumpSounds;
    [SerializeField] private AudioSource coinSound;
    [SerializeField] private AudioSource screamSound;

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
        ChangeMusicVolume();
        ChangeSoundsVolume();
    }

    //private void Start()
    //{
    //    ChangeMusicVolume();
    //    ChangeSoundsVolume();
    //}

    public void PlayMenuMusic()
    {
        if (SettingsAssistant.IsMusicPlaying)
        {
            backgroundMusic.volume = musicVolume;
            backgroundMusic.clip = mainMenuMusic;
            backgroundMusic.Play();
        }
        else
        {
            backgroundMusic.volume = 0;
        }
    }

    public void PlayGameMusic()
    {
        if (backgroundMusic.clip != gameMusic && SettingsAssistant.IsMusicPlaying)
        {
            backgroundMusic.clip = gameMusic;
            backgroundMusic.Play();
        }
    }

    public void PlayerJumpSoundPlay(string PlatformTag)
    {
        if (PlatformTag == "Platform")
        {
            jumpSounds.pitch = 1f;
        }
        else if (PlatformTag == "DoubleJumpPlatform")
        {
            jumpSounds.pitch = 1.4f;
        }

        jumpSounds.Play();
    }

    public void CoinCollectedSoundPlay()
    {
        coinSound.Play();
    }

    public void PlayerDiedSoundPlay()
    {
        if (SettingsAssistant.IsSoundsPlaying)
        {
            screamSound.clip = screamingClips[Random.Range(0, screamingClips.Length)];
            screamSound.Play();
        }
    }

    private void ChangeMusicVolume()
    {
        if (SettingsAssistant.IsMusicPlaying)
            backgroundMusic.volume = musicVolume;
        else
            backgroundMusic.volume = 0f;
    }

    private void ChangeSoundsVolume()
    {
        if (SettingsAssistant.IsSoundsPlaying)
        {
            jumpSounds.volume = soundsVolume;
            coinSound.volume = soundsVolume;
            screamSound.volume = 1f;
        }
        else
        {
            jumpSounds.volume = 0f;
            coinSound.volume = 0f;
            screamSound.volume = 0f;
        }
    }

    public void SoundsButtonPressed()
    {
        if (SettingsAssistant.IsSoundsPlaying)
            SettingsAssistant.IsSoundsPlaying = false;
        else
            SettingsAssistant.IsSoundsPlaying = true;

        ChangeSoundsVolume();
    }

    public void MusicButtonPressed()
    {
        if (SettingsAssistant.IsMusicPlaying)
            SettingsAssistant.IsMusicPlaying = false;
        else
            SettingsAssistant.IsMusicPlaying = true;

        ChangeMusicVolume();
    }
}
