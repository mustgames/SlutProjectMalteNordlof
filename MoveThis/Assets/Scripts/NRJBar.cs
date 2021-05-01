using UnityEngine.UI;
using UnityEngine;

public class NRJBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxNRJ(float NRJ)
    {
        slider.maxValue = NRJ;
        slider.value = NRJ;
    }
    public void SetNRJValue(float NRJ)

    {
        slider.value = NRJ;
    }
}
