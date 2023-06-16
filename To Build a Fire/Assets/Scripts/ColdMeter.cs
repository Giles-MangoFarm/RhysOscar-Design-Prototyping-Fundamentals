using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColdMeter : MonoBehaviour
{
    public Slider coldSlider;

    public void UpdateSLider (float value)
    {
        coldSlider.value = value;
    }
}
