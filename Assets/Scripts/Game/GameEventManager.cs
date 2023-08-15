using UnityEngine;
using UnityEngine.Events;

public class GameEventManager
{
    public static UnityEvent<int> OnActiveLevelElementEvent = new UnityEvent<int>();

    public static void DeActivateElement(int Y_playerPosition)
    {
        if (OnActiveLevelElementEvent != null)
            OnActiveLevelElementEvent.Invoke(Y_playerPosition);
    }
}
