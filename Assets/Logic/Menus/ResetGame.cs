using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    public void GameReset()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
    
    public void StartGame()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
    
    public void CloseGame()
    {
        Application.Quit();
    }
    
    
}
