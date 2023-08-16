using System;
using System.Threading.Tasks;
using UnityEngine;

public class MagnetEquipped : MonoBehaviour
{
    public float duration = 11f;
    public float radius = 10f;
    private LayerMask coinMask;
    

    private async void Start()
    {
        coinMask = 1 << LayerMask.NameToLayer("Money");

        Console.WriteLine("Starting asynchronous operation...");
        var task = MagnetTask();

        while (!task.IsCompleted)
        {
            GameEventManager.SendMagnetRemainingTime(duration - 1);
            await Task.Delay(1000);
            duration--;
        }
    }

    public async Task MagnetTask()
    {
        await Task.Delay(TimeSpan.FromSeconds(duration));
        DestroyMagnet();
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
        DestroyMagnet();
    }

    private void DestroyMagnet()
    {
        if (Application.isPlaying)
            Destroy(this);
        else
            DestroyImmediate(this);
    }
}
