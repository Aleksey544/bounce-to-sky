using UnityEngine;

public class MagnetItem : CollectibleItem
{
    public override void OnPlayerCollect(Collider colliderPlayer)
    {
        MagnetEquipped playerMagnet = colliderPlayer.GetComponent<MagnetEquipped>();

        if (playerMagnet == null)
        {
            colliderPlayer.gameObject.AddComponent<MagnetEquipped>();
        }
        else
        {
            playerMagnet.AddAdditionalSeconds();
        }

        gameObject.SetActive(false);
    }
}
