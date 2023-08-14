using UnityEngine;

public class MagnetCollector : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
           PlayerMagnet playerMagnet = collider.GetComponent<PlayerMagnet>();

           if (playerMagnet == null)
           {
                collider.gameObject.AddComponent<PlayerMagnet>();
           }
        }
    }
}
