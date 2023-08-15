using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    [SerializeField] private bool isMagnetize;
    [SerializeField] private Transform platformTarget;
    [SerializeField] private Vector3 offsetFromTarget = new Vector3(0, 0.3f, 0);
    [SerializeField] LayerMask layerMask;

    public virtual void Init(PlatformItem platform) {
        SetLayerMask();
        DeleteMagnet();
        SetToPlatform(platform);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            OnPlayerCollect(collider);
            RemoveFromPlatform();
        }
    }

    protected void DeleteMagnet()
    {
        MagnetMover magnetMover = gameObject.GetComponent<MagnetMover>();
        if (magnetMover != null) { Destroy(magnetMover); }
    }



    public void SetToPlatform(PlatformItem platform)
    {
        platformTarget = platform.transform;
    }

    public void RemoveFromPlatform() 
    {
      platformTarget = null;
    }

    public virtual void OnPlayerCollect(Collider colliderPlayer) { }



    public void Update()
    {
        if (platformTarget != null)
        {
            transform.position = platformTarget.position + offsetFromTarget;
        }
    }

    public void Magnetize(Transform playerTransform)
    {
        if (!isMagnetize) return;

        transform.gameObject.layer = LayerMask.NameToLayer("Default");
        gameObject.AddComponent<MagnetMover>().Init(playerTransform);
        //CollectibleItemRotator coinMovement = transform.GetComponent<CollectibleItemRotator>();
        //Destroy(coinMovement);
    }

    internal void SetLayerMask()
    {
        transform.gameObject.layer = layerMask;
    }

}