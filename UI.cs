using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    
    public void ChangeScene(string Level)
    {
        SceneManager.LoadScene(Level);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
 