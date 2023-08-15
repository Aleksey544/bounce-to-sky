using UnityEngine;

public class IsActiveObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
            gameObject.SetActive(false);
    }
}
