using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class misionesowo : MonoBehaviour
{
    public GameObject PauseMenu;
    
    public GameObject[] cartasnum;
    public static bool isPaused;
    
    public int numcard = 0;
    public TextMeshProUGUI textmeshpro;
    
    // Start is called before the first frame update

    IEnumerator Start()
    {
        //StartCoroutine("DoSomething", 2.0f);
        yield return new WaitForSeconds(3);
        //StopCoroutine("DoSomething");
        cartasnum = GameObject.FindGameObjectsWithTag("wifu"); 
        Debug.Log("owawawa");
    }


    void Awake()
    {
        PauseMenu.SetActive(false);
        
       // cartasnum = GameObject.FindGameObjectsWithTag("wifu"); 
    }

     void Update()
    {
        textmeshpro.text = cartasnum.Length.ToString();
        if(Input.GetKeyDown(KeyCode.Tab))
        {
           
            if(isPaused)
            {
                Resume();
            }else
            {
                PauseGame();
            }
        }
        

        
    }
    public void PauseGame()
    {
        PauseMenu.SetActive(true);
        //Time.timeScale = 0f;
        isPaused = true;
    }
    public void Resume()
    {
        PauseMenu.SetActive(false);
        //Time.timeScale = 1f;
        isPaused = false;
    }
    
}