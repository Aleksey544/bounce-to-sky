using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SoundButtonPanel : MonoBehaviour, IPointerClickHandler
{
    public Image imageOn;
    public Image imageOff;
    public bool isSound;

    public void OnPointerClick(PointerEventData eventData)
    {


        if (isSound)
        {

            SettingsAssistant.IsSoundsPlaying = !SettingsAssistant.IsSoundsPlaying;
            imageOff.enabled = !SettingsAssistant.IsSoundsPlaying;
            imageOn.enabled = SettingsAssistant.IsSoundsPlaying;
        }
        else
        {
            SettingsAssistant.IsMusicPlaying = !SettingsAssistant.IsMusicPlaying;
            imageOff.enabled = !SettingsAssistant.IsMusicPlaying;
            imageOn.enabled = SettingsAssistant.IsMusicPlaying;
        }
    }
}
