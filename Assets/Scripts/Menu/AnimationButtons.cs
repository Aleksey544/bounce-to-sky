using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnimationButtons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	public float XOffset = 0.2f;

	public void OnPointerEnter(PointerEventData eventData)
	{
		transform.DOScale(1.1f, 0.2f).SetId(this);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		transform.DOScale(1f, 0.2f).SetId(this);
	}

    public void OnDisable()
    {
		transform.localScale = Vector3.one;
		//DOTween.Kill(this);
		DOTween.KillAll();
    }
}
