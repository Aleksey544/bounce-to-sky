using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class RewardedAdsButtons : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] private Button _doubleCoinsButton;
    [SerializeField] private Button _secondLifeButton;
    [SerializeField] private PlayerManager _playerManager;
    // Id ��������� ������ (placement) � Unity Dashboard
    [SerializeField] private string _doubleCoinsUnityId = "Rewarded_Double_Coins";
    [SerializeField] private string _secondLifeUnityId = "Rewarded_Second_Life_";
    private string _AdUnityId;

    public void Init()
    {
        LoadAd();
        _doubleCoinsButton.interactable = false;
        _secondLifeButton.interactable = false;
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

        if (placementId == _doubleCoinsUnityId)
        {
            _doubleCoinsButton.interactable = true;
        }

        if (placementId == _secondLifeUnityId)
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
        }

        // LoadAd();
    }

    public void DoubleCoinsButtonPressed()
    {
        // Android
        _doubleCoinsButton.interactable = false;
        Advertisement.Show(_doubleCoinsUnityId, this);
    }

    public void SecondLifeButtonPressed()
    {
        // Android
        _secondLifeButton.interactable = false;
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
