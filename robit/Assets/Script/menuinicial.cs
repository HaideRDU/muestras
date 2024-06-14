using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(5);
    }

    public void QuitGame()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void OpenSettings()
    {
        SceneManager.LoadScene(2);
    }

    public void OpenCredits()
    {
        SceneManager.LoadScene(3);
    }
        public void OpenManual()
    {
        SceneManager.LoadScene(4);
    }
}
