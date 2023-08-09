using UnityEngine;

public class MainMenuInit : MonoBehaviour 
{

    private void Start()
    {
        if (SettingsAssistant.IsMusicPlaying)
            AudioManager.Ins.PlayMenuMusic();
    }
}