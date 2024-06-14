using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class cordura : MonoBehaviour
{
    public static float coordura;
    public Image imagen; 

    public GameObject coso;

    public bool delcoso;

    public GameObject muertetiempo;

    public GameObject canwa;


    void Start()
    {
        coordura = 100;
    }
    

    void Update()
    {
        coordura -= Time.deltaTime;

        if (coordura < 0)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            coordura = 0;
            canwa.SetActive(false);
            muertetiempo.SetActive(true);

            if (Input.GetKeyDown(KeyCode.R))
            {

                SceneManager.LoadScene(1);
                coordura = 100;
                vida.vidaActual = 100;
            }
        }

        UpdateImageOpacity();

       // Debug.Log(coordura);

        if(coordura < 25)
        {
            delcoso = !delcoso;

            coso.SetActive(delcoso);
        }
    }

    void UpdateImageOpacity()
    {
        float alpha = coordura / 100f;

        Color color = imagen.color;

        color.a = alpha;

        imagen.color = color;
    }
}