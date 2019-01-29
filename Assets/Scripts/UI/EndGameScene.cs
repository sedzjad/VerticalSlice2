using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameScene : MonoBehaviour
{

    public void GameStart()
    {
        SceneManager.LoadScene("KaartStuffs");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Button Test");
    }
}
