using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class AdsRewarded : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] private Button _doubleCoinsButton;
    [SerializeField] private Button _secondLifeButton;
    private bool _doubleCoinsAdsNotShowed = true;
    private bool _secondLifeAdsNotShowed = true;
    [SerializeField] private PlayerManager _playerManager;
    // Id рекламных единиц (placement) в Unity Dashboard
    [SerializeField] private string _doubleCoinsUnityId = "Rewarded_Double_Coins";
    [SerializeField] private string _secondLifeUnityId = "Rewarded_Second_Life_";

    public void Init()
    {
        _doubleCoinsButton.interactable = false;
        _secondLifeButton.interactable = false;
        LoadAd();
    }

    public void NoInteractibleButtons()
    {
        _doubleCoinsButton.interactable = false;
        _secondLifeButton.interactable = false;
    }

    public void LoadAd()
    {
        Advertisement.Load(_doubleCoinsUnityId, this);
        Advertisement.Load(_secondLifeUnityId, this);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        if (placementId == _doubleCoinsUnityId && _doubleCoinsAdsNotShowed)
        {
            _doubleCoinsButton.interactable = true;
        }

        if (placementId == _secondLifeUnityId && _secondLifeAdsNotShowed)
        {
            _secondLifeButton.interactable = true;
        }
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (placementId == _doubleCoinsUnityId && showCompletionState == UnityAdsShowCompletionState.COMPLETED)
        {
            _playerManager.DoubleCoinsForWatchAds();
        }

        if (placementId == _secondLifeUnityId && showCompletionState == UnityAdsShowCompletionState.COMPLETED)
        {
            _playerManager.SecondLifeForWatchAds();
        }
    }

    public void DoubleCoinsButtonPressed()
    {
        // Android
        _doubleCoinsButton.interactable = false;
        _doubleCoinsAdsNotShowed = false;
        Advertisement.Show(_doubleCoinsUnityId, this);
    }

    public void SecondLifeButtonPressed()
    {
        // Android
        _secondLifeButton.interactable = false;
        _secondLifeAdsNotShowed = false;
        Advertisement.Show(_secondLifeUnityId, this);
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message) { }

    public void OnUnityAdsShowClick(string placementId) { }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message) { }

    public void OnUnityAdsShowStart(string placementId) { }
}
