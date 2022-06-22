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
    public Image firstButtonStatusIcon;
    public Image selectedStatusIcon;
    public Sprite selected, notSelected;
    public int priceOfFirstItem;

    private string unlockMatrixPath, selectMatrixPath;

    void Start()
    {
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
