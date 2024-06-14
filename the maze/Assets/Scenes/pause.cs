using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
     public void Reiniciar()
    {
        SceneManager.LoadScene(3);
    }

    

    public void Salir()
    {
        SceneManager.LoadScene(0);
    }
    
    
}