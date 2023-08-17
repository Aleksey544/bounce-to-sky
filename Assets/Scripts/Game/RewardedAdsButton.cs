using UnityEngine;
using UnityEngine.Advertisements;

public class RewardedAdsButton : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] private string _androidAdUnityId = "Rewarded_Android";
    [SerializeField] private string _iOSAdUnityId = "Rewarded_iOS";
    private string _AdUnityId;
    public static RewardedAdsButton S;

    private void Awake()
    {
        S = this;

        _AdUnityId = (Application.platform == RuntimePlatform.IPhonePlayer) ? _iOSAdUnityId : _androidAdUnityId;
    }

    private void Start()
    {
        LoadAd();
    }

    public void LoadAd()
    {
        Advertisement.Load(_AdUnityId, this);
    }

    public void ShowAd()
    {
        Advertisement.Show(_AdUnityId, this);
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (placementId == _AdUnityId && showCompletionState == UnityAdsShowCompletionState.COMPLETED)
        {
            Debug.Log("_AdUnityId + Ads shown was completed!" + _AdUnityId + " ===  " + placementId);
        }

        LoadAd();
    }

    void IUnityAdsLoadListener.OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("OnUnityAdsAdLoaded");
    }

    void IUnityAdsLoadListener.OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log("OnUnityAdsFailedToLoad");
    }

    void IUnityAdsShowListener.OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log("OnUnityAdsShowFailure");
    }

    void IUnityAdsShowListener.OnUnityAdsShowStart(string placementId)
    {
        Debug.Log("OnUnityAdsShowStart");
    }

    void IUnityAdsShowListener.OnUnityAdsShowClick(string placementId)
    {
        Debug.Log("OnUnityAdsShowClick");
    }

}
