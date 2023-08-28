using DG.Tweening;
using UnityEngine;

public class SputnikItem : MonoBehaviour
{
    private float xMovingDestination = -11;
    private float yRotatePosition = 0;

    public void Init(float xMovingDestination, float yRotatePosition)
    {
        this.xMovingDestination = xMovingDestination;
        this.yRotatePosition = yRotatePosition;
        transform.localRotation = Quaternion.Euler(0, this.yRotatePosition, 0);
        Move();
    }

    private void Move()
    {
        transform.DOLocalMoveX(xMovingDestination, 4).SetId(this).OnComplete(() =>
        {
            xMovingDestination = -xMovingDestination;

            if (yRotatePosition == 0)
                yRotatePosition = 180;
            else if (yRotatePosition == 180)
                yRotatePosition = 0;

            transform.DOLocalRotate(new Vector3(0, yRotatePosition, 0), 1).SetId(this).OnComplete(() =>
            {
                Move();
            });
        }).SetEase(Ease.InOutSine);
    }

    private void OnDisable()
    {
        DOTween.Kill(this);
    }
}
