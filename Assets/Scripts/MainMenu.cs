using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject optionWindow;
    public void StartGamePlay()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGamePlay()
    {
        Application.Quit();
    }

    public void OpenOptionWindow()
    {
        optionWindow.SetActive(true);
    }

    public void OpenOption()
    {
        SceneManager.LoadScene(2);
    }

}
