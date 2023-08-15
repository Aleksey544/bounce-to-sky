using System;
using System.Threading.Tasks;
using UnityEngine;

public class MagnetEquipped : MonoBehaviour
{
    private float duration = 10f;
    private float radius = 10f;
    private LayerMask coinMask;

    private async void Start()
    {
        //Debug.Log("Start magnet");
        coinMask = 1<<LayerMask.NameToLayer("Money");
        await MagnetTask();
       // Debug.Log("end magnet");
    }

    public void FixedUpdate()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius, coinMask);

        foreach (var hitCollider in hitColliders)
        {
            CollectibleItem tempItem = hitCollider.GetComponent<CollectibleItem>();

            if (tempItem != null)
                tempItem.Magnetize(transform);

            Debug.Log(hitCollider.gameObject.name);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public async Task MagnetTask()
    {
       // Debug.Log("work magnet");
        await Task.Delay(TimeSpan.FromSeconds(duration));
        Destroy(this);
    }
}
