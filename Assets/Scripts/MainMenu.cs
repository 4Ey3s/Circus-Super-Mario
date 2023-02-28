using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1.0f;
        
    }
    public void QuitGame ()
    {
        Application.Quit();
        Debug.Log("Quit!");

    }
}