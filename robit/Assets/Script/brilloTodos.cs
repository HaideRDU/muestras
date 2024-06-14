using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class brilloTodos : MonoBehaviour
{
    private Image imgComponent;

    void Start()
    {
        GameObject luzObject = GameObject.FindWithTag("Luz");

        if (luzObject != null)
        {
            imgComponent = luzObject.GetComponent<Image>();

            if (imgComponent != null)
            {
                Color currentColor = imgComponent.color;
                currentColor.a = brillo.sliderValue;
                imgComponent.color = currentColor;
            }           
        }
    }
}