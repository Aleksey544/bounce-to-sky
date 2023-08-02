using UnityEngine;
using UnityEngine.EventSystems;

public class BackButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject Shop;
    public GameObject MainMenu;
    public SkinSelection playerSkin;

    public void OnPointerClick(PointerEventData eventData)
    {
        Shop.SetActive(false);
        MainMenu.SetActive(true);
        playerSkin.InitPlayerSelectedSkin();
    }
}
