using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public static MenuController menuController;
    public GameObject mainButtons;
    public GameObject mainInstructions;
    public GameObject backButton;
    private void Start()
    {
        menuController = this;
    }
    public void loadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void reloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Instructions()
    {
        mainButtons.SetActive(false);
        mainInstructions.SetActive(true);
        backButton.SetActive(true);
    }

    public void Back()
    {
        mainButtons.SetActive(true);
        mainInstructions.SetActive(false);
        backButton.SetActive(false);
    }

    public void quitGame()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }

}

