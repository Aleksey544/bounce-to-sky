using UnityEngine;

public class MainMenuInit : MonoBehaviour 
{
    private void Start()
    {
        AudioManager.Ins.PlayMenuMusic();
    }
}