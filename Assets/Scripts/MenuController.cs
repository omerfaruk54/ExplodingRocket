using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("Game");
    }
    public void MenuButton()
    {
        SceneManager.LoadScene("Menu");
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("Menu 1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
