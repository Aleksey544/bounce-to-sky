using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private AdsRewarded rewardedAds;

    private void OnEnable()
    {
        rewardedAds.LoadAd();
    }
}
