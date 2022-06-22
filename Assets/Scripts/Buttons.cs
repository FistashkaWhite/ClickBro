using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Buttons : MonoBehaviour
{

    public Text count;
    int clickCount = 0;
    public Text stopWatch;
    float currentTime;
    public int startMinutes;
    bool timerActive = false;
    public Text sliderValue;
    public Slider slider;
    public GameObject sliderObject;
    public Animator animator;
    public Button ClickButton;

    void Start()
    {
        currentTime = startMinutes * 60;
    }

    public void Update()
    {
        //clickAmount = slider.value;

        count.text = clickCount + "";
        //sliderValue.text = slider.value.ToString();
        stopWatch.text = currentTime.ToString();

         if(timerActive == true)
         {
            currentTime = currentTime + Time.deltaTime;
         }

        if(clickCount >= SetClicks.clickAmount )
        {
            timerActive = false;
        }

        if(clickCount > 0)
        {
            sliderObject.SetActive(false);
        }
    }

    public void Click()
    {
        animator.SetTrigger("Clicked");
        clickCount++;
        if(timerActive == false)
        {
            if(clickCount < SetClicks.clickAmount)
            {
                timerActive = true;
            }
        }

    }

    public void ResetCount()
    {
        if(clickCount > 0)
        {
            clickCount = 0;
        }
        sliderObject.SetActive(true);
        currentTime = 0;
        timerActive = false;
    }

/*    public void ChangeColour(object sender, EventArgs e)
    {
        ClickButton.pressedColor = Color.white;
    }*/

}
