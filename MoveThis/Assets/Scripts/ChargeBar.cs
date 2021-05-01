using UnityEngine.UI;
using UnityEngine;

public class ChargeBar : MonoBehaviour
{

    public Slider slider;
    
    public void SetMaxCharge(float charge)
    {
        slider.maxValue = charge;
        slider.value = charge;
    }
    public void SetChargeValue(float charge)

    {
        slider.value = charge;
    }
}
