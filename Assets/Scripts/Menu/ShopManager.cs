using System.Collections.Generic;
using System.Drawing;
using DG.Tweening;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public int shownSkinIndex = 0;
    public TMP_Text CoinsText;
    public TMP_Text PriceText;
    public Image PriceCoin;
    public UnityEngine.Color CoinsColorNormal;
    public UnityEngine.Color CoinsColorNoMoney;
    public float speed = 0.5f;
    public List<BallSkin> ballSkins = new List<BallSkin>();
    public Button SelectButton;
    public Sprite SelectImage;
    public Sprite SelectedImage;
    public Sprite BuyImage;
    public AnimationButtons SelectButtonAnimation;
    public SkinSelection playerSkin;
    public BallSkin shownSkin;

    private void OnEnable()
    {
        CoinsText.text = SettingsAssistant.Coins.ToString();
        playerSkin.InstantiateSkin(SettingsAssistant.SelectedSkin);
        UpdateShopUI();
    }

    [ContextMenu("DeletePrefs")]
    public void DeletePrefs()
    {
        SettingsAssistant.DeleteAllPrefs();
    }

    [ContextMenu("SetCoins")]
    public void SetCoins()
    {
        SettingsAssistant.Coins += 10000;
    }

    private void ShowSkin()
    {
        playerSkin.InstantiateSkin(shownSkin.Name);
        UpdateShopUI();
    }

    public void UpdateShopUI()
    {
        if (isBoughtShownSkin())
        {
            if (SettingsAssistant.SelectedSkin == shownSkin.Name)
            {
                SelectButton.image.sprite = SelectedImage;
                SelectButtonAnimation.enabled = false;
            }
            else
            {
                SelectButton.image.sprite = SelectImage;
                SelectButtonAnimation.enabled = true;
            }

            PriceText.enabled = false;
            PriceCoin.enabled = false;
        }
        else
        {
            SelectButton.image.sprite = BuyImage;
            PriceText.enabled = true;
            PriceCoin.enabled = true;
            PriceText.text = $"{ballSkins[shownSkinIndex].Price}";
        }

    }

    public bool isBoughtShownSkin() 
    {
        return SettingsAssistant.BoughtSkin(shownSkin.Name);
    }

    public void SelectOrBuyButtonPressed()
    {
        if (isBoughtShownSkin())
        {
            SelectSkin();
        }
        else
        {
            BuySkin();
        }
    }

    private void BuySkin()
    {
        if (SettingsAssistant.Coins >= shownSkin.Price)
        {
            SettingsAssistant.Coins -= shownSkin.Price;
            SettingsAssistant.SetBoughtSkin(shownSkin.Name);
            CoinsText.text = SettingsAssistant.Coins.ToString();
            UpdateShopUI();
        }
        else
        {
            CoinsText.DOColor(CoinsColorNoMoney, speed).OnComplete(
                () => CoinsText.DOColor(CoinsColorNormal, speed));
            CoinsText.color = UnityEngine.Color.white;
        }
    }

    private void SelectSkin()
    {
        SettingsAssistant.SelectedSkin = shownSkin.Name;
        playerSkin.InitPlayerSelectedSkin();
        UpdateShopUI();
    }

    public void LeftButtonPressed()
    {
        if (shownSkinIndex != 0)
        {
            shownSkinIndex--;
        }
        else if (shownSkinIndex == 0)
        {
            shownSkinIndex = ballSkins.Count - 1;
        }

        shownSkin = ballSkins[shownSkinIndex];
        ShowSkin();
    }

    public void RightButtonPressed()
    {
        shownSkinIndex++;

        if (shownSkinIndex == ballSkins.Count)
        {
            shownSkinIndex = 0;
        }

        shownSkin = ballSkins[shownSkinIndex];
        ShowSkin();
    }
}