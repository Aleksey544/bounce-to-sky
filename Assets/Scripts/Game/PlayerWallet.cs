using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWallet : MonoBehaviour
{
	public int Coins = 0;
	public TMP_Text CoinsText;
	
	
	private void Start()
	{
        OnCoinsUpdated();
    }

	public void AddCoins()
	{
		SettingsAssistant.Coins++;
		OnCoinsUpdated();
	}

	public void OnCoinsUpdated() 
	{
        CoinsText.text = SettingsAssistant.Coins.ToString();
    }
}
