using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text MagnetRemainingTimeTextTMP;
    [SerializeField] private Image MagnetImage;

    private void OnEnable()
    {
        EventManager.Ins.OnMagnetRemainingTimeEvent.AddListener(UpdateMagnetRemainingTime);
        EventManager.Ins.OnActiveMagnetUIElementsEvent.AddListener(ActiveMagnetUIElements);
    }
    private void OnDisable()
    {
        EventManager.Ins.OnMagnetRemainingTimeEvent.RemoveListener(UpdateMagnetRemainingTime);
        EventManager.Ins.OnActiveMagnetUIElementsEvent.RemoveListener(ActiveMagnetUIElements);
    }

    public void UpdateMagnetRemainingTime(float remainingSeconds)
    {
        MagnetRemainingTimeTextTMP.text = remainingSeconds.ToString();
    }

    public void ActiveMagnetUIElements(bool isActive)
    {
            Debug.Log(isActive);
            MagnetRemainingTimeTextTMP.enabled = isActive;
            MagnetImage.enabled = isActive;    
    }
}
