using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CountCoins : MonoBehaviour
{
    public int clickCount;
    public int Coins;
    public int SpentCoins;
    public TMP_Text CoinAmount;

    private void Start()
    {
        clickCount = PlayerPrefs.GetInt("ClickCount");
        Coins = PlayerPrefs.GetInt("Coins");
    }

    private void Update()
    {
        PlayerPrefs.SetInt("ClickCount", clickCount);//------------------------------CLICK COUNT

        Coins = Mathf.FloorToInt(clickCount / 10) - PlayerPrefs.GetInt("SpentCoins");
        PlayerPrefs.SetInt("Coins", Coins);//------------------------------------COINS

        CoinAmount.text = "AMOUNT OF COINS: " + Coins.ToString();
    }

    public void AddClicks()
    {
        clickCount++;
    }
}
