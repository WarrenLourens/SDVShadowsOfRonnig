using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
  
    public void StartGameRonnin()
    {
        SceneManager.LoadScene("Intro");
    }
    public void BeginStart()
    {
        SceneManager.LoadScene("Game");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
