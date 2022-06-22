using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


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
    public Color ButtonColour;
    public Color DefaultButtonColour;
    public Image ImageColour;
    public bool isPressed = false;

    void Start()
    {
        currentTime = startMinutes * 60;
    }

    public void Update()
    {
        if (isPressed)
        {
            ImageColour.color = ButtonColour;
        }
        else if(!isPressed)
        {
            ImageColour.color = DefaultButtonColour;
        }


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
    public void OnPointerDown()
    {
        isPressed = true;
        //Debug.Log("checkDown");

    }

    public void OnPointerUp()
    {
        isPressed = false;
        //Debug.Log("checkUp");

    }
}
