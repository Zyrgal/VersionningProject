using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{

    public static LoadSceneManager instance = null;

    public void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    public void UI_Play()
    {
        gameObject.GetComponent<MenuManager>().canPause = true;
        MenuManager.instance.CloseStartMenu();
        SceneManager.LoadScene(1);
    }

    public void UI_Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameObject.GetComponent<MenuManager>().CloseWinMenu();
        gameObject.GetComponent<MenuManager>().CloseLoseMenu();
        gameObject.GetComponent<MenuManager>().ClosePauseMenu();
    }

    public void UI_BackToMenu()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(0);
    }

    public void UI_Quit()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
