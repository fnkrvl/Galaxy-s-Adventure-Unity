using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    
    public void LoadMenu(string Level)
    {
        Time.timeScale = 1f;
        Debug.Log("Loading game...");
        SceneManager.LoadScene(Level);
    }        


    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

}
