using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Cinemachine;

public class pistas : MonoBehaviour
{
    public GameObject pistamenu;
    public bool pausa = false;

    public bool actpausa = false;

    public CinemachineBrain awa;


    public GameObject pista1;

    public GameObject hudmapa;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            pistamenu.SetActive(true);

            actpausa = true;
            //if (Input.GetKey(KeyCode.E))
            //{
            //    pausa = !pausa;
            //}
            //if(pausa == true)
            //{
            //    Time.timeScale = 0f;
            //    pistamenu.SetActive(true);
            //}else if(pausa == false)
            //{
            //    pistamenu.SetActive(false);
            //    Time.timeScale = 1f;
            //}
        }else
        {
            //pistamenu.SetActive(false);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            actpausa = false;
            pistamenu.SetActive(false);
            //Time.timeScale = 1.0f;
        }
    }

    public void Update()
    {
        awa = Camera.main.GetComponent<CinemachineBrain>();

        if (actpausa == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                pausa = !pausa;

                if (pausa) 
                {
                    
                    Time.timeScale = 0.0f;

                    awa.enabled = false;
                    pista1.SetActive(true);
                    hudmapa.SetActive(false);

                } else
                {

                    hudmapa.SetActive(true);

                    puerta.llaves ++;
                    cordura.coordura = cordura.coordura + 25f;
                    pistamenu.SetActive(false);
                    pista1.SetActive(false);
                    Time.timeScale = 1.0f;
                    awa.enabled = true;
                    Destroy(gameObject);

                }
                
            }
        }

        if (actpausa == false)
        {
            //pistamenu.SetActive(false);
        }
    }
}
