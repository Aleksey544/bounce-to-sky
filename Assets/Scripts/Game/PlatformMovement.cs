using UnityEngine;
using DG.Tweening;


public class PlatformMovement : MonoBehaviour
{
    public Vector3 defaultPosition;

    public void Init()
    {
        //DOTween.Kill(this);
        transform.localPosition = defaultPosition;
        transform.DOLocalMoveX(0.75f, 2.5f).SetLoops(-1, LoopType.Yoyo).SetId(this).SetEase(Ease.InOutSine);
    }

    private void OnDisable()
    {
        DOTween.Kill(this);
    }
}
