using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PlayButton : MonoBehaviour, IPointerClickHandler
{
	public void OnPointerClick(PointerEventData eventData)
	{

        AudioManager.Instantiate.PlayGameMusic();
        SceneManager.LoadScene("RandomLevel");
	}
}
