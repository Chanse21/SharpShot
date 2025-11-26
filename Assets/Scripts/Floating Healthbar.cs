using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class FloatingHealthBar : MonoBehaviour
{

    public Slider slider;
    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        if (slider != null)
        slider.value = currentValue / maxValue;
    }

}