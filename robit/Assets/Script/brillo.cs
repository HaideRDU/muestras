using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class brillo : MonoBehaviour
{
    public Slider slider;
    private Image imgComponent;

    public static float sliderValue = 0.5f; 

    void Start()
    {
        GameObject luzObject = GameObject.FindWithTag("Luz");

        if (luzObject != null)
        {
            imgComponent = luzObject.GetComponent<Image>();

            if (imgComponent != null && slider != null)
            {
                slider.value = sliderValue;

                Color currentColor = imgComponent.color;
                currentColor.a = sliderValue;
                imgComponent.color = currentColor;

                slider.onValueChanged.AddListener(OnSliderValueChanged);
            }
           
        }
        
    }

    public void OnSliderValueChanged(float value)
    {
        sliderValue = value;

        if (imgComponent != null)
        {
            Color currentColor = imgComponent.color;
            currentColor.a = value;
            imgComponent.color = currentColor;
        }
    }

    
}
