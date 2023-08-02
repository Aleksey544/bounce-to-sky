using System.Collections;
using UnityEngine;

public class SkinSelection : MonoBehaviour
{
    private GameObject currentSkin;
    public GameObject Player;

    private void Start()
    {
        InitPlayerSelectedSkin();
    }

    public void InitPlayerSelectedSkin()
    {
        InstantiateSkin(SettingsAssistant.SelectedSkin);
    }

    public void InstantiateSkin(string skinName)
    {
        GameObject loadedSkin = Resources.Load<GameObject>($"BallSkins/{skinName}");

        if (currentSkin != null)
            Destroy(currentSkin);

        if (loadedSkin != null)
            currentSkin = Instantiate(loadedSkin);
        else
            Debug.Log("Can't load this skin: " + skinName);

        currentSkin.transform.SetParent(Player.transform);
        currentSkin.transform.localScale = Vector3.one;
        currentSkin.transform.localRotation = Quaternion.identity;
        currentSkin.transform.localPosition = Vector3.zero;
    }

}