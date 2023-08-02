//Скрипт уничтожения игрового об'екта
using UnityEngine;

public class DestroyObjectScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
            Destroy (gameObject);
    }
}
