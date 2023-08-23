using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MagnetMover : MonoBehaviour
{
    private Transform targetPlayer;
    public float moveSpeed = 30f;

    public void Init(Transform targetPlayer)
    {
        this.targetPlayer = targetPlayer;
        transform.parent.SetParent(null, true);
       
    }

    public void Delete()
    {
        Destroy(this);
    }

    void Update()
    {
        // ¬ычисл€ем направление к целевой точке
        Vector3 direction = (targetPlayer.position - transform.position).normalized;

        // ¬ычисл€ем рассто€ние до цели
        float distanceToTarget = Vector3.Distance(transform.position, targetPlayer.position);

        // ≈сли рассто€ние до цели больше некоторого минимального значени€ (чтобы избежать дрожани€ около цели)
        if (distanceToTarget > 0.1f)
        {
            // ƒвигаем объект в направлении к цели с заданной скоростью
           transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }
}
