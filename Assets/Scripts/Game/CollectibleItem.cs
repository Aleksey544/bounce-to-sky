using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    [SerializeField] private bool isMagnetize;
    [SerializeField] private Transform platformTarget;
    [SerializeField] private Vector3 offsetFromTarget = new Vector3(0, 0.3f, 0);
    [SerializeField] LayerMask layerMask;

    public virtual void Init(Transform targetPlatfrom) {
        SetLayerMask();
        DeleteMagnet();
        platformTarget = targetPlatfrom.transform;
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



    public void RemoveFromPlatform() 
    {
      platformTarget = null;
    }

    public virtual void OnPlayerCollect(Collider colliderPlayer) { }



    private void Update()
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
        RemoveFromPlatform();
        //CollectibleItemRotator coinMovement = transform.GetComponent<CollectibleItemRotator>();
        //Destroy(coinMovement);
    }

    internal void SetLayerMask()
    {
        transform.gameObject.layer =  ToLayer (layerMask);
    }
    
    public static int ToLayer ( int bitmask ) {
        int result = bitmask>0 ? 0 : 31;
        while( bitmask>1 ) {
            bitmask = bitmask>>1;
            result++;
        }
        return result;
    }
}