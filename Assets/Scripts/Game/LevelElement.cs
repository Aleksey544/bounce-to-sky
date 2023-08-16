using UnityEngine;

// Любой игровой элемент, который предполагается включать и выключать неоднократно
public class LevelElement : MonoBehaviour
{
    [SerializeField] private Transform elementPrefab;

    public Transform ElementPrefab { get => elementPrefab; set => elementPrefab = value; }

    private void OnEnable()
    {
        EventManager.Ins.OnActiveLevelElementEvent.AddListener(ActiveElement);
    }

    private void OnDisable()
    {
        EventManager.Ins.OnActiveLevelElementEvent.RemoveListener(ActiveElement);
    }

    public void ActiveElement(int current_Y_playerPosition)
    {
        if (current_Y_playerPosition >= Mathf.FloorToInt(transform.position.y) + 5)
            gameObject.SetActive(false);
    }
}
