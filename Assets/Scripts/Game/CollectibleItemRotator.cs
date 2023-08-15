using System;
using DG.Tweening;
using UnityEngine;

// Анимация вращения предметов, которые подбирает игрок
public class CollectibleItemRotator : MonoBehaviour
{
    [SerializeField] private float speed = 3f;

    private void OnEnable()
    {
        transform.DOLocalRotate(new Vector3(0, 360, 0), speed, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear).SetId(this);
    }

    private void OnDisable()
    {
        DOTween.Kill(this);
    }
}