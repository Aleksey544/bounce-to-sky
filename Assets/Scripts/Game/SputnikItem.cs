using DG.Tweening;
using UnityEngine;

public class SputnikItem : MonoBehaviour
{
    private float xMovingIncrement = -11;
    private float yRotatingIncrement = 0;

    public void Init()
    {
        transform.localRotation = Quaternion.Euler(0, yRotatingIncrement, 0);
        Move();
    }

    private void Move()
    {
        transform.DOLocalMoveX(xMovingIncrement, 4).SetId(this).OnComplete(() =>
        {
            xMovingIncrement = -xMovingIncrement;

            if (yRotatingIncrement == 0)
                yRotatingIncrement = 180;
            else if (yRotatingIncrement == 180)
                yRotatingIncrement = 0;

            Debug.Log(yRotatingIncrement);

            //Rotate();
            transform.DOLocalRotate(new Vector3(0, yRotatingIncrement, 0), 1).SetId(this).OnComplete(() =>
            {
                Move();
            });
        }).SetEase(Ease.InOutSine);
    }

    //private void MoveBack()
    //{
    //    transform.DOLocalMoveX(15, 5f).OnComplete(() =>
    //    {
    //        RotateAndInit();
    //    }).SetId(this).SetEase(Ease.InOutSine);
    //}
    //private void Rotate()
    //{
    //    transform.DOLocalRotate(new Vector3(0f, 180f, 0f), 1f).OnComplete(() => { MoveBack(); });
    //}

    //private void RotateAndInit()
    //{
    //    transform.DOLocalRotate(new Vector3(0f, 0f, 0f), 1).OnComplete(() => { Move(); });
    //}

    private void OnDisable()
    {
        DOTween.Kill(this);
    }
}
