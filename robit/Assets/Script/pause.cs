using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;

    [SerializeField] private GameObject awa;

    private bool juegopausado = false;

    public void Start()
    {
        Reanudar();
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (juegopausado)
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                awa.SetActive(true);
                Reanudar();
            }
            else
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                //Cursor.lockState = CursorLockMode.Locked;

                awa.SetActive(false);
                Pausa();
            }
        }
    }

    public void Pausa()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        juegopausado = true;
        Time.timeScale = 0f;
        AudioSource[] audios = FindObjectsOfType<AudioSource>();
        foreach (AudioSource a in audios)
        {
            a.Pause();
        }
        botonPausa.SetActive(false);
        menuPausa.SetActive(true);
    }
    public void Reanudar()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        awa.SetActive(true);

        juegopausado = false;
        Time.timeScale = 1f;
        AudioSource[] audios = FindObjectsOfType<AudioSource>();
        foreach (AudioSource a in audios)
        {
            a.Play();
        }
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);
    }
    public void Reiniciar()
    {
        juegopausado = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);
    }

    public void Cerrar()
    {
        Debug.Log("Cerrando juego");
        Application.Quit();
    }
    public void inicio()
    {
        SceneManager.LoadScene(1);
    }




}