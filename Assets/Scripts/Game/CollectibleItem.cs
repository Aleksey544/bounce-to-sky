using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    [SerializeField] private bool isMagnetize;
    [SerializeField] private Transform platformTarget;
    [SerializeField] private Vector3 offsetFromTarget = new Vector3(0, 0.3f, 0);
    [SerializeField] string layerMask;
    private AudioManager audioManager;

    public void Start()
    {
        audioManager = AudioManager.Ins;
    }

    public void OnEnable()
    {
        SetIgnoreMagnetingLayer();
    }

    public void CanMagnetAfterSeconds()
    {
        SetLayerMask();
    }

    public virtual void Init(Transform targetPlatfrom) {
        Invoke(nameof(CanMagnetAfterSeconds), 2);
        transform.position = targetPlatfrom.position;
        platformTarget = targetPlatfrom.transform;
        DeleteMagnet();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            OnPlayerCollect(collider);
            RemoveFromPlatform();
            SetIgnoreMagnetingLayer();
            audioManager.CoinCollectedSoundPlay();
        }
    }

    protected void DeleteMagnet()
    {
        gameObject.GetComponent<MagnetMover>()?.Delete();      
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

    public void SetIgnoreMagnetingLayer() 
    {
        transform.gameObject.layer = LayerMask.NameToLayer("Default");
    }

    public void Magnetize(Transform playerTransform)
    {
        if (!isMagnetize) return;

        SetIgnoreMagnetingLayer();
        gameObject.AddComponent<MagnetMover>().Init(playerTransform);
        RemoveFromPlatform();
    }

    internal void SetLayerMask()
    {
        transform.gameObject.layer = LayerMask.NameToLayer(layerMask);
    }
}