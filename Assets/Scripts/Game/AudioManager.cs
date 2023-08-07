using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] screamingSounds;
    [SerializeField] private AudioSource jumpAudio;
    [SerializeField] private AudioSource coinAndDieAudio;

    public void PlayerJumpOnPlatform(string PlatformTag)
    {
        if (PlatformTag == "Platform")
        {
            jumpAudio.pitch = 1f;
        }
        else if (PlatformTag == "DoubleJumpPlatform")
        {
            jumpAudio.pitch = 1.4f;
        }

        jumpAudio.Play();
    }

    public void CoinCollected()
    {
        coinAndDieAudio.Play();
    }

    public void PlayerDied()
    {
        coinAndDieAudio.clip = screamingSounds[Random.Range(0, screamingSounds.Length)];
        coinAndDieAudio.volume = 1f;
        coinAndDieAudio.Play();
    }
}
