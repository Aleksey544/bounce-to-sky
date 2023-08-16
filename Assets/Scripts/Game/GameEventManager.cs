using UnityEngine;
using UnityEngine.Events;

public class GameEventManager
{
    public static UnityEvent<int> OnActiveLevelElementEvent = new UnityEvent<int>();
    public static UnityEvent<float> OnMagnetRemainingTimeEvent = new UnityEvent<float>();

    public static void DeActivateElement(int Y_playerPosition)
    {
        if (OnActiveLevelElementEvent != null)
            OnActiveLevelElementEvent.Invoke(Y_playerPosition);
    }    
    
    public static void SendMagnetRemainingTime(float remainingSeconds)
    {
        if (OnMagnetRemainingTimeEvent != null)
            OnMagnetRemainingTimeEvent.Invoke(remainingSeconds);
    }
}
