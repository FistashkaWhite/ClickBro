using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public UnlockableMatrix unlockableMatrix;
    public SelectableMatrix selectableMatrix;

    public TMP_Text FirstButtonPrice;
    public Sprite lockedImage, unlockedImage;
    public Button firstButtonCheck; // BUTTONS!
    public Image firstButtonStatusIcon, secondButtonStatusIcon;
    public Image selectedStatusIcon, selectedStatusIcon2;
    public Sprite selected, notSelected;
    public int priceOfFirstItem;
    public int priceOffSecondItem;

    private string unlockMatrixPath, selectMatrixPath;

    void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("SecondItem"));


        //PlayerPrefs.SetInt("SpentCoins", 0);//---------------------------------------RESET SPENT COINS
        FirstButtonPrice.text = priceOfFirstItem.ToString() + " Coins"; 
        //PlayerPrefs.SetInt("Coins", 100); //---------------------------------------MY COINTS CURRENTLY

        //-----------------------------------------------------------------------------------------
        unlockMatrixPath = $"{Application.persistentDataPath}/UnlockMatrix.json";

        if (File.Exists(unlockMatrixPath))
        {
            string Unlockablejson = File.ReadAllText(unlockMatrixPath);
            unlockableMatrix = JsonUtility.FromJson<UnlockableMatrix>(Unlockablejson);
        }

        //-----------------------------------------------------------------------------------------

        selectMatrixPath = $"{Application.persistentDataPath}/selectMatrix.json";

        if (File.Exists(selectMatrixPath))
        {
            string Selectablejson = File.ReadAllText(selectMatrixPath);
            selectableMatrix = JsonUtility.FromJson<SelectableMatrix>(Selectablejson);
        }
    }

    public void buyFirstButton()
    {
        //unlockableMatrix.hasFirstButton = false;//-------------------------------RESET BUY 1 BUTTON

        if(unlockableMatrix.hasFirstButton == false)
        {
            if(PlayerPrefs.GetInt("Coins") >= priceOfFirstItem)
            {
                unlockableMatrix.hasFirstButton = true;
                PlayerPrefs.SetInt("SpentCoins", PlayerPrefs.GetInt("SpentCoins") + priceOfFirstItem);

            }

        }
                if (unlockableMatrix.hasFirstButton == true)
                {
                    if (selectableMatrix.FirstButtonSelected == true)
                    {
                        selectedStatusIcon.sprite = notSelected;
                        selectableMatrix.FirstButtonSelected = false;
                    }
                    else if (selectableMatrix.FirstButtonSelected == false)
                    {
                        selectedStatusIcon.sprite = selected;
                        selectableMatrix.FirstButtonSelected = true;
                    }
                }
                //PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins")-priceOfFirstItem);
                RerenderShop();
                SaveJson();   


    }

    public void buySecondButton()
    {
        if (PlayerPrefs.GetInt("SecondItem") == 0)
        {
            if (PlayerPrefs.GetInt("Coins") >= priceOffSecondItem)
            {
                PlayerPrefs.SetInt("SecondItem", 1);
                PlayerPrefs.SetInt("SpentCoins", PlayerPrefs.GetInt("SpentCoins") + priceOffSecondItem);
            }

        }
        if (PlayerPrefs.GetInt("SecondItem") == 1)
        {
            if (PlayerPrefs.GetInt("SecondItemSelected") == 1)
            {
                selectedStatusIcon2.sprite = notSelected;
                PlayerPrefs.SetInt("SecondItemSelected", 0);
            }
            else if (PlayerPrefs.GetInt("SecondItemSelected") == 0)
            {
                selectedStatusIcon2.sprite = selected;
                PlayerPrefs.SetInt("SecondItemSelected", 1);
            }
        }

    }





    public void RerenderShop()
    {
        if(unlockableMatrix.hasFirstButton)
        {
            firstButtonStatusIcon.sprite = unlockedImage;
        }
        else
        {
            firstButtonStatusIcon.sprite = lockedImage;
        }

        if(selectableMatrix.FirstButtonSelected == true)
        {
            selectedStatusIcon.sprite = selected;
        }
        else
        {
            selectedStatusIcon.sprite = notSelected;
        }
        //---------------------------------------------------------2(remove) - make array
        if (PlayerPrefs.GetInt("SecondItem") == 1)
        {
            secondButtonStatusIcon.sprite = unlockedImage;
        }
        else
        {
            secondButtonStatusIcon.sprite = lockedImage;
        }

        if (PlayerPrefs.GetInt("SecondItemSelected") == 1)
        {
            selectedStatusIcon2.sprite = selected;
        }
        else
        {
            selectedStatusIcon2.sprite = notSelected;
        }
    }

    private void SaveJson()
    {
        string Unlockablejson = JsonUtility.ToJson(unlockableMatrix);
        File.WriteAllText(unlockMatrixPath, Unlockablejson);

        //--------------------------------------------------------

        string Selectablejson = JsonUtility.ToJson(selectableMatrix);
        File.WriteAllText(selectMatrixPath, Selectablejson);
    }

    private void Update()
    {
        RerenderShop();
    }
}
