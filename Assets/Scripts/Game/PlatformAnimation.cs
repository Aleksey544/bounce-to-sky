using DG.Tweening;
using UnityEngine;

public class PlatformAnimation : MonoBehaviour
{
    public void PlatformAnimationPush()
    {
        transform.DOScale(new Vector3(1f, 4f, 1f), 0.25f).SetId(this).OnComplete(() =>
        {
            transform.DOScale(new Vector3(1f, 1f, 1f), 0.25f).SetId(this);
        });

    }

    public void OnDisable()
    {
        DOTween.Kill(this);
    }
}
