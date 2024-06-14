using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigoCamara : MonoBehaviour
{
    public Transform jugador;
    public float distanciaDeSeguimiento = 30f;
    public float distanciaDeDetencion = 20f;
    public float tasaDeDisparo = 1f;
    private float tiempoSiguienteDisparo = 0f;

    public float velocidadDeLaBala = 10f;

    public GameObject proyectilPrefab;

    public GameObject puntoDeDisparo;

    private bool isRotating = false;

    private AudioSource audioSource;

    
    void Update()
    {
        audioSource = GetComponent<AudioSource>();
        float distanciaAlJugador = Vector3.Distance(jugador.position, transform.position);

        if (distanciaAlJugador <= distanciaDeSeguimiento && distanciaAlJugador > distanciaDeDetencion)
        {
            MirarJugador(); // Alerta
        }
        else if (distanciaAlJugador <= distanciaDeDetencion)
        {
            DetenerYDisparar(); // Ataque
        }
        else
        {
            DejarDeRotar(); // Relax
        }
    }

    void MirarJugador()
    {
        isRotating = true;
        RotarHaciaJugador();
    }

    void DetenerYDisparar()
    {
        isRotating = true;
        RotarHaciaJugador();

        if (Time.time > tiempoSiguienteDisparo)
        {
            Disparar();
            tiempoSiguienteDisparo = Time.time + 1f / tasaDeDisparo;
        }
    }

    void DejarDeRotar()
    {
        isRotating = false;
    }

    void RotarHaciaJugador()
    {
        Vector3 direccion = (jugador.position - transform.position).normalized;
        Quaternion rotacionMirar = Quaternion.LookRotation(direccion);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotacionMirar, Time.deltaTime * 5f);
    }

    void Disparar()
    {
        audioSource.enabled = true;

        Vector3 direccionDisparo = (jugador.position - transform.position).normalized;
        Vector3 posicionDisparo = puntoDeDisparo.transform.position;

        GameObject proyectil = Instantiate(proyectilPrefab, posicionDisparo, Quaternion.LookRotation(direccionDisparo));

        Rigidbody rb = proyectil.GetComponent<Rigidbody>();

        rb.velocity = direccionDisparo * velocidadDeLaBala;

        audioSource.Play();
    }
}