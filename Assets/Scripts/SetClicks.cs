using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetClicks : MonoBehaviour
{

    public Text sliderValue;
    public Slider slider;
    public static float clickAmount;


    public void Update()
    {
        clickAmount = slider.value;

        sliderValue.text = slider.value.ToString();
    }
}
