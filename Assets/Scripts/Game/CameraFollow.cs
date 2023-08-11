//Скрипт следования камеры за игроком
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
		//transform.position = player.position + offset; //жесткая привяхка камеры к игроку по всем осям
		Vector3 pos1 = new Vector3(player.position.x, transform.position.y, transform.position.z); //жёсткая привяхка по оси Х
		//transform.position = Vector3.Lerp(transform.position, player.position + offset, Time.deltaTime * speed); //свободная камера
		transform.position = Vector3.Lerp(pos1, player.position + offset, Time.deltaTime * speed); //жёсткая привяхка по оси Х
	}
}
