using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiempoventana : MonoBehaviour
{
    public float tiempazo = 5;

    void Update()
    {
        tiempazo -= Time.deltaTime;

        if ( tiempazo < 0 )
            Destroy( gameObject );
    }
}
