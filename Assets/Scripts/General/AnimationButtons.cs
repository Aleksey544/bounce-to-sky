using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnimationButtons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	private Transform currentTransform;
    private string animationId = "AnimationButtons";
    private void Start()
    {        
        currentTransform = transform;
    }

    public void OnPointerEnter(PointerEventData eventData)
	{
        
		transform.DOScale(1f, 0.2f).SetId(animationId);
    }

	public void OnPointerExit(PointerEventData eventData)
	{
		transform.DOScale(0.9f, 0.2f).SetId(animationId);
	}

    public void OnDisable()
    {
        transform.localScale = new Vector3(0.9f, 0.9f, 1f);
        DOTween.Kill(animationId);
    }
}
