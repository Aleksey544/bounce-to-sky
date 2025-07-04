using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SoundButtonPanel : MonoBehaviour, IPointerClickHandler
{
    public Image imageOn;
    public Image imageOff;
    public bool isSound;

    public void Start()
    {
        if (isSound)
        {
            InitButton(SettingsAssistant.IsSoundsPlaying);
        }
        else 
        {
            InitButton(SettingsAssistant.IsMusicPlaying);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isSound)
        {
            AudioManager.Ins.SoundsButtonPressed();
            InitButton(SettingsAssistant.IsSoundsPlaying);
        }
        else
        {
            AudioManager.Ins.MusicButtonPressed();
            InitButton(SettingsAssistant.IsMusicPlaying);
        }
    }

    private void InitButton(bool active)
    {
        imageOff.enabled = !active;
        imageOn.enabled = active;
    }
}
