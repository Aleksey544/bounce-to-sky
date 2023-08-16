using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    private static EventManager ins;

    public void Awake()
    {
        if (ins == null) { ins = this; } else { Destroy(this); }
    }

    public UnityEvent<int> OnActiveLevelElementEvent;
    public UnityEvent<float> OnMagnetRemainingTimeEvent;
    public UnityEvent<bool> OnActiveMagnetUIElementsEvent;

    public static EventManager Ins { get => ins; set => ins = value; }

    public void DeActivateElement(int Y_playerPosition)
    {
        OnActiveLevelElementEvent?.Invoke(Y_playerPosition);
    }
    public void SendMagnetRemainingTime(float remainingSeconds)
    {
        OnMagnetRemainingTimeEvent?.Invoke(remainingSeconds);
    }
    public void ActiveMagnetUIElements(bool isActive)
    {
        OnActiveMagnetUIElementsEvent?.Invoke(isActive);
    }
}
