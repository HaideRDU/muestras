using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuPasua : MonoBehaviour
{
    
    [SerializeField] private GameObject menuPausa;

    public Rigidbody rb;
    
    private bool cursorHabilitado = false;

    private bool juegopausado=false;

    

    public void Update(){
        if (Input.GetKeyDown(KeyCode.Escape)){
            if(juegopausado){
                Reanudar();
            }else
            {
                Pausa();
            }
            
        }
    }

    public void Pausa(){
        juegopausado=true;
        Time.timeScale=0f;
        AudioSource[] audios=FindObjectsOfType<AudioSource>();
        foreach(AudioSource a in audios){
            a.Pause();
        }
        
        menuPausa.SetActive(true);

        cursorHabilitado = !cursorHabilitado;

            // Habilitar o deshabilitar el cursor según el estado
            Cursor.lockState = cursorHabilitado ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = cursorHabilitado;
    }
    public void Reanudar(){
        Debug.Log("reanudar");
        juegopausado=false;
        Time.timeScale=1f;
         AudioSource[] audios=FindObjectsOfType<AudioSource>();
        foreach(AudioSource a in audios){
            a.Play();
        }
        
        menuPausa.SetActive(false);

        cursorHabilitado = !cursorHabilitado;

            // Habilitar o deshabilitar el cursor según el estado
            Cursor.lockState = cursorHabilitado ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = cursorHabilitado;
    }

     
    public void Cerrar(){
        Debug.Log("Cerrando juego");
        SceneManager.LoadScene(0);
    }

        public void Reiniciar(){
            Debug.Log("reiniciar");
        juegopausado=false;
        Time.timeScale=1f;
       // Progreso.DatosBarra.ReBarra(0);
        SceneManager.LoadScene(3);
        
        menuPausa.SetActive(false);

        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero; // Esto detendrá la rotación también, si es relevante
        }
    }



}
