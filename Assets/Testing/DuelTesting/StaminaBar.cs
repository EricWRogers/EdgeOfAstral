using SuperPupSystems.Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{

    public Slider slider;

    public void SetFullStamina(int stamina)
    {
        slider.maxValue = stamina;
        slider.value = stamina;
    }

    public void SetStamina(int stamina)
    {
        slider.value = stamina;
    }

    public void LowerStamina(int stamina)
    {
        if(slider.value > slider.minValue)
            slider.value -= stamina;
        else
            slider.value = slider.minValue;
    }

    public void RaiseStamina(int stamina)
    {
        if(slider.value < slider.maxValue)
            slider.value += stamina;
        else
            slider.value = slider.maxValue;

    }

}
