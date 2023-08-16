using UnityEngine;

public class CoinItem : CollectibleItem
{   
    public override void OnPlayerCollect(Collider colliderPlayer)
    {
        DeleteMagnet();
        colliderPlayer.GetComponent<PlayerManager>().AddCoins();   
        gameObject.SetActive(false);
    }
}
