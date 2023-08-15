using UnityEngine;

public class CoinItem : CollectibleItem
{   
    public override void OnPlayerCollect(Collider colliderPlayer) 
    {
        colliderPlayer.GetComponent<PlayerManager>().AddCoins();
        base.DeleteMagnet();
        gameObject.SetActive(false);
    }
}
