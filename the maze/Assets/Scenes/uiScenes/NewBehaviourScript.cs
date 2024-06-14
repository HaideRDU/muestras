using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
     public void Reiniciar()
    {
        SceneManager.LoadScene(3);
    }

    public void Salir()
    {
        Debug.Log("Saliendo...");
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    
}
