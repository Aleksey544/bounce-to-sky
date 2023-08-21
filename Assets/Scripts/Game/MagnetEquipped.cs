using System;
using System.Threading.Tasks;
using UnityEngine;

public class MagnetEquipped : MonoBehaviour
{
    public const float durationSeconds = 10f;
    private float remainingSeconds = durationSeconds;
    public float radius = 10f;
    private LayerMask coinMask;
    
    private async void Start()
    {
        coinMask = 1 << LayerMask.NameToLayer("Money");

        await MagnetTask();
    }

    public async Task MagnetTask()
    {
        EventManager.ActiveMagnetUIElements(true);

        while (remainingSeconds > 0)
        {
            EventManager.SendMagnetRemainingTime(remainingSeconds);
            await Task.Delay(1000);
            remainingSeconds--;
        }

        EventManager.SendMagnetRemainingTime(remainingSeconds);
        EventManager.ActiveMagnetUIElements(false);
        DestroyMagnet();
    }

    public void AddAdditionalSeconds()
    {
        remainingSeconds += durationSeconds;
    }

    public void FixedUpdate()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius, coinMask);

        foreach (var hitCollider in hitColliders)
        {
            CollectibleItem tempItem = hitCollider.GetComponent<CollectibleItem>();

            if (tempItem != null)
                tempItem.Magnetize(transform);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private void OnDisable()
    {
        EventManager.ActiveMagnetUIElements(false);
        DestroyMagnet();
    }

    private void DestroyMagnet()
    {
        if (Application.isPlaying)
            Destroy(this);
        else
            DestroyImmediate(this);

        remainingSeconds = 0;
    }
}
