using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class ActivateItems : MonoBehaviour
{
    public SelectableMatrix selectableMatrix;
    public GameObject firstAnimation;
    private string selectMatrixPath;
    public GameObject SecondItem;
    public void Start()
    {
        selectMatrixPath = $"{Application.persistentDataPath}/selectMatrix.json";

        if (File.Exists(selectMatrixPath))
        {
            string Selectablejson = File.ReadAllText(selectMatrixPath);
            selectableMatrix = JsonUtility.FromJson<SelectableMatrix>(Selectablejson);
        }
    }

    private void CheckForChange()
    {
        if (selectableMatrix.FirstButtonSelected == true)
        {
            firstAnimation.SetActive(true);
        }
        else
        {
            firstAnimation.SetActive(false);
        }

        if(PlayerPrefs.GetInt("SecondItemSelected") == 1)
        {
            SecondItem.SetActive(true);
        }
        else
        {
            SecondItem.SetActive(false);
        }
    }

    private void Update()
    {
        CheckForChange();
    }
}
