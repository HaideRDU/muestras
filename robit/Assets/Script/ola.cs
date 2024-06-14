using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ola : MonoBehaviour
{
    public float contador;

    void Update()
    {
        contador += Time.deltaTime;

        if (contador > 52)
        {
            SceneManager.LoadScene(1);
        }
        Debug.Log(contador);
    }

}
