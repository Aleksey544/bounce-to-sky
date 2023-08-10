using UnityEngine;
using UnityEngine.Events;

public class GameEventManager
{
    public static UnityEvent<int> OnActivePlatformEvent = new UnityEvent<int>();

    public static void DeActivatePlatform(int Y_playerPosition)
    {
        if (OnActivePlatformEvent != null)
            OnActivePlatformEvent.Invoke(Y_playerPosition);
    }
}
