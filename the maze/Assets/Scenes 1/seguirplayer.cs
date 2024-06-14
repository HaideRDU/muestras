using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using UnityEngine;

public class seguirplayer : MonoBehaviour
{   

    public GameObject vida1;
    public GameObject vida2;
    public GameObject vida3;


    private bool cursorHabilitado = true;
   [SerializeField] Transform target;
    NavMeshAgent agent;
    public bool atacar=false;
    public GameObject screamer;
    public static bool isPaused;
    private Vector3 originalPosition;

    public double saludd=3f;

    private bool delayActive = false;
    private float delayTimer = 0.75f;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        screamer.SetActive(false);
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {    
        float dist = Vector3.Distance(target.transform.position, transform.position);
        agent.SetDestination(target.position);
        transform.LookAt(target);
        

        if (dist < 2)
    {
        atacar = true;
        PauseGame();

        // Establece la posición en (0, 0) y agrega un retraso
        if (!delayActive)
        {
            StartCoroutine(MoveToOriginalPositionWithDelay());
        }
    }
    else
    {
        atacar = false;
        Resume();
    }

       if(saludd==2){
        vida3.SetActive(false);
       }
       if(saludd==1){
        vida2.SetActive(false);
       }

        if(saludd==0){
            vida3.SetActive(false);
           Debug.Log("cambio OWO");
           SceneManager.LoadScene("Perdiste"); 
           cursorHabilitado = !cursorHabilitado;

            // Habilitar o deshabilitar el cursor según el estado
            Cursor.lockState = cursorHabilitado ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = cursorHabilitado;
        }
    }
        private IEnumerator MoveToOriginalPositionWithDelay()
    {
        saludd--;
        delayActive = true;
        // Agrega un retraso antes de mover al enemigo a la posición original
        yield return new WaitForSeconds(delayTimer);
        transform.position = originalPosition;
        delayActive = false;
    }
     public void PauseGame()
    {
        screamer.SetActive(true);
        //Time.timeScale = 0f;
        isPaused = true;
        

    }
    public void Resume()
    {
        screamer.SetActive(false);
        //Time.timeScale = 1f;
        isPaused = false;
    }
}