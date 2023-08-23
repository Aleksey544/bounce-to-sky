// Скрипт следования камеры за игроком
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float speed;

    private void Start()
    {
        transform.Rotate(18f, 0, 0); //x = 18
    }

    private void LateUpdate()
    {
		Vector3 pos1 = new Vector3(player.position.x, transform.position.y, transform.position.z);
		transform.position = Vector3.Lerp(pos1, player.position + offset, Time.deltaTime * speed);
	}
}
