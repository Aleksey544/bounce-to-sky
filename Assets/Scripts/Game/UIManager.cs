using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text MagnetRemainingTimeTextTMP;
    [SerializeField] private Image MagnetImage;

    private void OnEnable()
    {
        EventManager.OnMagnetRemainingTimeEvent.AddListener(UpdateMagnetRemainingTime);
        EventManager.OnActiveMagnetUIElementsEvent.AddListener(ActiveMagnetUIElements);
    }
    private void OnDisable()
    {
        EventManager.OnMagnetRemainingTimeEvent.RemoveListener(UpdateMagnetRemainingTime);
        EventManager.OnActiveMagnetUIElementsEvent.RemoveListener(ActiveMagnetUIElements);
    }

    public void UpdateMagnetRemainingTime(float remainingSeconds)
    {
        MagnetRemainingTimeTextTMP.text = remainingSeconds.ToString();
    }

    public void ActiveMagnetUIElements(bool isActive)
    {
            MagnetRemainingTimeTextTMP.enabled = isActive;
            MagnetImage.enabled = isActive;    
    }
}
