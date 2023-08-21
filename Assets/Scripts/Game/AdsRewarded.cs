using System.Collections;
using System.Collections.Generic;
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
    private string _AdUnityId;

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
        Debug.Log("Loading Ad: ");
        Advertisement.Load(_doubleCoinsUnityId, this);
        Advertisement.Load(_secondLifeUnityId, this);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("OnUnityAdsAdLoaded = " + placementId);

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
        Debug.Log("OnUnityAdsShowComplete" + placementId);

        if (placementId == _doubleCoinsUnityId && showCompletionState == UnityAdsShowCompletionState.COMPLETED)
        {
            Debug.Log("Coins were doubled === " + placementId);
            _playerManager.DoubleCoinsForWatchAds();
        }

        if (placementId == _secondLifeUnityId && showCompletionState == UnityAdsShowCompletionState.COMPLETED)
        {
            Debug.Log("Life was seconded === " + placementId);
            _playerManager.SecondLifeForWatchAds();
        }

        // LoadAd();
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

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log("OnUnityAdsFailedToLoad");
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        Debug.Log("OnUnityAdsShowClick");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log("OnUnityAdsShowFailure");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log("OnUnityAdsShowStart");
    }
}
