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
        // ��������� ����������� � ������� �����
        Vector3 direction = (targetPlayer.position - transform.position).normalized;

        // ��������� ���������� �� ����
        float distanceToTarget = Vector3.Distance(transform.position, targetPlayer.position);

        // ���� ���������� �� ���� ������ ���������� ������������ �������� (����� �������� �������� ����� ����)
        if (distanceToTarget > 0.1f)
        {
            // ������� ������ � ����������� � ���� � �������� ���������
           transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }
}
