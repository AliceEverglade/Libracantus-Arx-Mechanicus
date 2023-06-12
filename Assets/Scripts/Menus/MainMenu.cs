using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    public void PlayGame()
    {
        SceneManager.LoadScene("Start");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene("Cristian");
    }

    public void sceneTransition(string sceneName)
    {
        
    }

    public void sceneThemeSelect()
    {
        SceneManager.LoadScene("ThemeSelector");
    }
}
