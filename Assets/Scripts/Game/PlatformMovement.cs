using System.Collections;
using UnityEngine;
using DG.Tweening;
using System;

public class PlatformMovement : MonoBehaviour
{
    public AnimationCurve Easing;
    private Vector3 targetPosition;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.localPosition;
        targetPosition = transform.localPosition + Vector3.right * 3;
        
        //StartCoroutine(MoveCoroutine());
    }

    private void OnEnable()
    {
        transform.DOLocalMoveX(3f, 2.5f).SetLoops(-1, LoopType.Yoyo).SetId(this).SetEase(Easing);
    }

    private void OnDisable()
    {
        DOTween.Kill(this);
    }

    IEnumerator MoveCoroutine()
    {
        while (true)
        {
            for (float i = 0; i < 1; i += Time.deltaTime / 3)
            {
                transform.localPosition = Vector3.Lerp(startPosition, targetPosition, Easing.Evaluate(i));

                yield return null;
            }
        }
    }
}
