using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Transform platformModel;

    public Transform PlatformModel { get => platformModel; set => platformModel = value; }

    private void OnEnable()
    {
        GameEventManager.OnActivePlatformEvent.AddListener(ActivePlatform);
    }

    private void OnDisable()
    {
        GameEventManager.OnActivePlatformEvent.RemoveListener(ActivePlatform);
    }

    public void ActivePlatform(int current_Y_playerPosition)
    {
        if (current_Y_playerPosition >= Mathf.FloorToInt(transform.position.y) + 5)
            gameObject.SetActive(false);
    }
}
