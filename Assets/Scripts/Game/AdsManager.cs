using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] private bool testMod;
    [SerializeField] private string androidGameId = "5385191";
    [SerializeField] private string iOSGameId = "5385190";
    [SerializeField] private RewardedAdsButtons rewardedAdsButtons;
    private string gameId;

    private void Awake()
    {
        InitializeAds();
    }

    public void InitializeAds()
    {
        gameId = (Application.platform == RuntimePlatform.IPhonePlayer) ? iOSGameId : androidGameId;

        Advertisement.Initialize(gameId, testMod, this);
    }

    void IUnityAdsInitializationListener.OnInitializationComplete()
    {
        rewardedAdsButtons.Init();
    }

    void IUnityAdsInitializationListener.OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        rewardedAdsButtons.NoInteractibleButtons();
    }
}
