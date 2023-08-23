using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class AnimationRewardedButtons : MonoBehaviour
{
    private void OnEnable()
    {
        if (gameObject.GetComponent<Button>().interactable == true)
            transform.DOScale(1.05f, 0.6f).SetLoops(-1, LoopType.Yoyo).SetId(this).SetEase(Ease.InOutSine);
    }

    public void KillAnimation()
    {
        transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
        DOTween.Kill(this);
    }

    private void OnDisable()
    {
        KillAnimation();
    }
}
