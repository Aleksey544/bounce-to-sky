using UnityEngine;

public class CoinsCollector : MonoBehaviour
{
	private void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "Player")
		{
			collider.GetComponent<PlayerWallet>().AddCoins();
		}
	}
}
