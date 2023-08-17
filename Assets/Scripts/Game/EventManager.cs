using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    //private static EventManager ins;

    //public void Awake()
    //{
    //    if (ins == null) { ins = this; } else { Destroy(this); }
    //}

    //public static EventManager Ins { get => ins; set => ins = value; }

    public static UnityEvent<int> OnActiveLevelElementEvent = new UnityEvent<int>();
    public static UnityEvent<float> OnMagnetRemainingTimeEvent = new UnityEvent<float>();
    public static UnityEvent<bool> OnActiveMagnetUIElementsEvent = new UnityEvent<bool>();

    public static void DeActivateElement(int Y_playerPosition)
    {
        OnActiveLevelElementEvent?.Invoke(Y_playerPosition);
    }

    public static void SendMagnetRemainingTime(float remainingSeconds)
    {
        OnMagnetRemainingTimeEvent?.Invoke(remainingSeconds);
    }

    public static void ActiveMagnetUIElements(bool isActive)
    {
        OnActiveMagnetUIElementsEvent?.Invoke(isActive);
    }
}
