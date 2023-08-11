using System;
using DG.Tweening;
using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offsetFromTarget = new Vector3(0, 0.3f, 0);

    public Transform Target { get => target; set => target = value; }

    private void OnEnable()
    {
        transform.DOLocalRotate(new Vector3(0, 360, 0), speed, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear).SetId(this);
    }

    private void OnDisable()
    {
        DOTween.Kill(this);
    }

    public void Update()
    {
        if (Target != null)
        {
            transform.localPosition = Target.localPosition + offsetFromTarget;
        }
    }

    internal void SetTarget(Transform platformModel)
    {
        target = platformModel;
    }
}