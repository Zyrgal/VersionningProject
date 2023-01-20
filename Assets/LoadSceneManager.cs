using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    public void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void UI_Play()
    {
        gameObject.GetComponent<MenuManager>().canPause = true;
        SceneManager.LoadScene(1);
    }

    public void UI_Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
