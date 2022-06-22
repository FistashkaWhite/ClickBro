using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Stats : MonoBehaviour
{
    public TMP_Text clicks, spentCoins, coins;

    public void Start()
    {
        coins.text = (PlayerPrefs.GetInt("Coins") + PlayerPrefs.GetInt("SpentCoins")).ToString();
        spentCoins.text = PlayerPrefs.GetInt("SpentCoins").ToString();
        clicks.text = PlayerPrefs.GetInt("ClickCount").ToString();
    }
}
