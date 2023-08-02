using DG.Tweening;
using UnityEngine;

public class CoinMovement : MonoBehaviour
{
	public float speed = 3f;

	private void Start()
	{
		transform.DOLocalRotate(new Vector3(0, 360, 0), speed, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear).SetId(this);
	}

	private void OnDisable()
	{
		DOTween.Kill(this);
	}
}