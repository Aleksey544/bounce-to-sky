using System.Collections;
using UnityEngine;
using DG.Tweening;
using System;

public class PlatformMovement : MonoBehaviour
{
    public Vector3 defaultPosition;
    public void Init()
    {
        Debug.Log("Init");
        DOTween.Kill(GetId());
        transform.localPosition = defaultPosition;
        transform.DOLocalMoveX(0.75f, 2.5f).SetLoops(-1, LoopType.Yoyo).SetId(GetId()).SetEase(Ease.InOutSine);
    }

    private int GetId()
    {
        return gameObject.GetInstanceID();
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        DOTween.Kill(GetId());
    }
}
