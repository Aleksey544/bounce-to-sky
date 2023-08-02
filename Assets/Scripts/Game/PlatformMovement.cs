using System.Collections;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public AnimationCurve Easing;
    private Vector3 targetPosition;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        targetPosition = transform.position + Vector3.right * 3;

        StartCoroutine(MoveCoroutine());
    }

    IEnumerator MoveCoroutine()
    {
        while (true)
        {
            for (float i = 0; i < 1; i += Time.deltaTime / 3)
            {
                transform.position = Vector3.Lerp(startPosition, targetPosition, Easing.Evaluate(i));

                yield return null;
            }
        }
    }
}
