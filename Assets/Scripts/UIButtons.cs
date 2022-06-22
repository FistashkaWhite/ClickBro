using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{

    public void Play()
    {
        SceneManager.LoadScene("SETTINGS");
    }

    public void Continue()
    {
        SceneManager.LoadScene("GAME");
    }

    public void BACK()
    {
        SceneManager.LoadScene("WELCOME");
    }

    public void Customization()
    {
        SceneManager.LoadScene("CUSTOMIZATION");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
