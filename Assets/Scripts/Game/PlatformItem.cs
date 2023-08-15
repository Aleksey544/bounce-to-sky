using UnityEngine;

public class PlatformItem : MonoBehaviour
{
    public PlatformMovement platformMovement;
    [SerializeField] private Transform content;

    public void Init() {

        if (platformMovement != null) 
        {
            platformMovement.Init();
        }
    }

    public void AddContentToChild(Transform contentItem) 
    {
        contentItem.SetParent(transform.GetChild(0).transform);
        //if (platformMovement != null)
            
    }

    public void RemoveContentToChild(Transform contentItem)
    {
        contentItem.SetParent(null);
    }
}
