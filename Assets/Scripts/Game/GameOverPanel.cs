using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private AdsRewarded rewardedAds;

    private void OnEnable()
    {
        rewardedAds.LoadAd();
    }
}
