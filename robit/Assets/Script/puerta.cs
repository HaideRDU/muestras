using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puerta : MonoBehaviour
{
    public static int llaves = 0;

    public GameObject puertaz;

    private void Update()
    {
        if(llaves >= 3)
        {
            puertaz.SetActive(true);
        }
        else
        {
            puertaz.SetActive(false);
        }

        Debug.Log(llaves);
    }
}
