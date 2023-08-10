using UnityEngine;

public class DestroyObjectScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
            gameObject.SetActive(false);
    }
}
