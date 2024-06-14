using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
     public void Jugar()
    {
        SceneManager.LoadScene(1);
    }

    public void Salir()
    {
        Debug.Log("Saliendo...");
        Application.Quit();
    }

    public void Opciones()
    {
        SceneManager.LoadScene(2);
    }

    public void Volver()
    {
         SceneManager.LoadScene(0);
    }
     public void sigue(){
        SceneManager.LoadScene(3);

    }
}