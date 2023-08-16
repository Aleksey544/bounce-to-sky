using UnityEngine;

public class PlatformItem : MonoBehaviour
{
    public PlatformMovement platformMovement;
    [SerializeField] private Transform content;

    public Transform GetPlatformContent()
    {
        return content;
    }

    public void Init() 
    {
        if (platformMovement != null) 
        {
            platformMovement.Init();
        }
    }
}
