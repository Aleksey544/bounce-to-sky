using UnityEngine;
using UnityEngine.EventSystems;

public class ShopButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject Shop;
    public GameObject MainMenu;
    public ShopManager shopManager;

    public void OnPointerClick(PointerEventData eventData)
    {
        Shop.SetActive(true);
        MainMenu.SetActive(false);
    }

    void OnEnable()
    {
        transform.localPosition = Vector3.zero;
    }
}
