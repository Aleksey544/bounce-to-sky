using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MagnetMover : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 30f;

    public Transform movingTransform;
    public void Init(Transform target)
    {
        this.target = target;
        gameObject.layer = LayerMask.NameToLayer("Default");
        transform.parent.SetParent(null, true);
        movingTransform = transform.parent;
        CoinMovement coinMovement =  transform.parent.GetComponent<CoinMovement>();
        Destroy(coinMovement);
    }
    void Update()
    {
        // ¬ычисл€ем направление к целевой точке
        Vector3 direction = (target.position - movingTransform.position).normalized;

        // ¬ычисл€ем рассто€ние до цели
        float distanceToTarget = Vector3.Distance(movingTransform.position, target.position);

        // ≈сли рассто€ние до цели больше некоторого минимального значени€ (чтобы избежать дрожани€ около цели)
        if (distanceToTarget > 0.1f)
        {
            // ƒвигаем объект в направлении к цели с заданной скоростью
           movingTransform.position += direction * moveSpeed * Time.deltaTime;
        }
    }

  
}
