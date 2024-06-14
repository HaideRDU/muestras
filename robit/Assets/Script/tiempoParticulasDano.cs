using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiempoParticulasDano : MonoBehaviour
{
    float coso = 0.0f;

    public void Update()
    {
        coso+= 0.1f;

        if ( coso >10)
            Destroy(gameObject);
    }
}