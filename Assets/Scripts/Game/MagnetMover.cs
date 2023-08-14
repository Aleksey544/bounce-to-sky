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
        // ��������� ����������� � ������� �����
        Vector3 direction = (target.position - movingTransform.position).normalized;

        // ��������� ���������� �� ����
        float distanceToTarget = Vector3.Distance(movingTransform.position, target.position);

        // ���� ���������� �� ���� ������ ���������� ������������ �������� (����� �������� �������� ����� ����)
        if (distanceToTarget > 0.1f)
        {
            // ������� ������ � ����������� � ���� � �������� ���������
           movingTransform.position += direction * moveSpeed * Time.deltaTime;
        }
    }

  
}
