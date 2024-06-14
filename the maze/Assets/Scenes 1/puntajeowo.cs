using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class puntajeowo : MonoBehaviour
{
    float puntajee=0.0f;
    public Slider timerSlider;
    public float totalTime = 60.0f; // 5 minutos en segundos
    public float currentTime;
    public TextMeshProUGUI textmeshpro;
    public misionesowo misionesScript;
    public int cartas;
    
   
    void Awake()
    {
        misionesScript = FindObjectOfType<misionesowo>(); 
    }
    
    IEnumerator Start()
    {   currentTime = totalTime;
        yield return new WaitForSeconds(3);
       
        //UpdateTimerUI();
         cartas = misionesScript.cartasnum.Length;
        //misionesScript.cartasnum.Length;
        Debug.Log(cartas);
        /*if (misionesScript != null)
        {
            GameObject[] cartas = misionesScript.cartasnum;
            
        
            cantidadCartas = cartas.Length;
            Debug.Log(cantidadCartas);
        }*/
        
    }

    // Update is called once per frame
    void Update()
    {   
        if (timerSlider != null)
       {
            timerSlider.value = 1 - (currentTime / totalTime);
       }

         if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
        
        }else
        {
            // El temporizador ha terminado. Puedes tomar medidas aquí.
            Debug.Log("¡Tiempo agotado!");
            currentTime = 0;
           // UpdateTimerUI();
            //SceneManager.LoadScene("perdida"); // Carga la escena de pérdida
        }
    }
    private void OnTriggerEnter(Collider other)
    {   
        if(other.CompareTag("wifu"))
        {   
            
            puntajee++;
            textmeshpro.text = puntajee.ToString();
            // Aumenta el tiempo en 10 segundos por cada punto
            currentTime += 10.0f;
            //UpdateTimerUI();
            //Debug.Log("aQWAWAW");
            Destroy(other.gameObject);
        }
        if(other.CompareTag("puerta"))
        {   
            if(puntajee == cartas)
            {
                Debug.Log("ganaste");
                SceneManager.LoadScene("Ganaste"); 
            }else
            {
                Debug.Log("faltan llaves OWO");
            }
        }

    }

}
