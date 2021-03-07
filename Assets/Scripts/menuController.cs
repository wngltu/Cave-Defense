using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuController : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene("game");
    }

    public void closeGame()
    {
        Application.Quit();
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("menu");
    }
    public void creditScreen()
    {
        SceneManager.LoadScene("credits");
    }
}
