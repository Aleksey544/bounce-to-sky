using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TMP_Text MagnetRemainingTimeTextTMP;

    private void Start()
    {
        GameEventManager.OnMagnetRemainingTimeEvent.AddListener(UpdateMagnetRemainingTime);
    }

    public void UpdateMagnetRemainingTime(float remainingSeconds)
    {
        MagnetRemainingTimeTextTMP.text = remainingSeconds.ToString();
    }
}
