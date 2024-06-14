using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemigoseguir : MonoBehaviour
{
    public Transform jugador;
    public float distanciaDeSeguimiento = 30f;
    public float distanciaDeDetencion = 20f;
    public float tasaDeDisparo = 1f;
    private float tiempoSiguienteDisparo = 0f;

    public float velocidadDeLaBala = 10f;

    public GameObject proyectilPrefab;

    public GameObject puntoDeDisparo;

    private NavMeshAgent agente;

    public Transform navigationObject;
    public float moveRadius = 10f;
    private bool isMovingRandomly = false;

    private AudioSource audioSource;

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float distanciaAlJugador = Vector3.Distance(jugador.position, transform.position);

        if (distanciaAlJugador <= distanciaDeSeguimiento && distanciaAlJugador > distanciaDeDetencion)
        {
            SeguirJugador(); //alerta
        }
        else if (distanciaAlJugador <= distanciaDeDetencion)
        {
            DetenerYDisparar(); //ataque
        }
        else
        {
            DetenerMovimiento(); //relax
        }
    }

    void SeguirJugador()
    {
        isMovingRandomly = false;
        agente.isStopped = false;
        agente.SetDestination(jugador.position);
        agente.speed = 0.2f;
    }

    void DetenerYDisparar()
    {
        isMovingRandomly = false;
        agente.isStopped = true;

        Vector3 direccion = (jugador.position - transform.position).normalized;
        Quaternion rotacionMirar = Quaternion.LookRotation(new Vector3(direccion.x, 0, direccion.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotacionMirar, Time.deltaTime * 5f);

        if (Time.time > tiempoSiguienteDisparo)
        {
            Disparar();
            tiempoSiguienteDisparo = Time.time + 1f / tasaDeDisparo;
        }
    }

    void DetenerMovimiento()
    {
        if (!isMovingRandomly)
        {
            isMovingRandomly = true;
            agente.speed = 2f;
            StartCoroutine(MoveRandomly());
        }
    }

    void Disparar()
    {
        audioSource.enabled = true;
        Vector3 direccionDisparo = (jugador.position - transform.position).normalized;
        Vector3 posicionDisparo = puntoDeDisparo.transform.position;

        GameObject proyectil = Instantiate(proyectilPrefab, posicionDisparo, Quaternion.LookRotation(direccionDisparo));

        Rigidbody rb = proyectil.GetComponent<Rigidbody>();

        rb.velocity = direccionDisparo * velocidadDeLaBala;

        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    IEnumerator MoveRandomly()
    {
        while (isMovingRandomly)
        {
            Vector3 randomDirection = Random.insideUnitSphere * moveRadius;
            randomDirection += navigationObject.position;

            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomDirection, out hit, moveRadius, NavMesh.AllAreas))
            {
                agente.SetDestination(hit.position);
                agente.isStopped = false;
            }

            yield return new WaitForSeconds(Random.Range(2f, 5f));

            float distanciaAlJugador = Vector3.Distance(jugador.position, transform.position);
            if (distanciaAlJugador <= distanciaDeSeguimiento)
            {
                isMovingRandomly = false;
            }
        }
    }
}
