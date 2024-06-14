using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public string targetTag = "Player";
    public string targetTag2 = "otrascosas";
    public GameObject toquePlayer;
    public GameObject toqueEscena;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            Instantiate(toquePlayer, gameObject.transform.position, Quaternion.identity);

            
            Debug.Log(vida.vidaActual);

            Destroy(gameObject);
        }

        if (other.CompareTag(targetTag2))
        {
            Instantiate(toqueEscena, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        Destroy(gameObject);
    }

    
    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag(targetTag))
        {
            ///Instantiate(toquePlayer, new Vector3(0, 0, 0), Quaternion.identity);
            //Destroy(gameObject);
        }
    }
}