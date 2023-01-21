using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance = null;

    public bool isPause = false;
    [HideInInspector]
    public bool canPause = false;

    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject winMenu;
    [SerializeField] GameObject loseMenu;
    [SerializeField] GameObject startMenu;

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
    }

    public void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (!isPause && canPause)
            {
                UI_Pause();
            }
            else
            {
                UI_Resume();
            }
        }
    }

    public void UI_Pause()
    {
        isPause = true;
        //Time.timeScale = 0;
        OpenPauseMenu();
    }

    public void UI_Resume()
    {
        isPause = false;
        //Time.timeScale = 1;
        ClosePauseMenu();
    }
    public void OpenStartMenu()
    {
        startMenu.SetActive(true);
    }

    public void CloseStartMenu()
    {
        startMenu.SetActive(false);
    }

    public void OpenPauseMenu()
    {
        isPause = true;
        pauseMenu.SetActive(true);
    }

    public void ClosePauseMenu()
    {
        isPause = false;
        pauseMenu.SetActive(false);
    }

    public void OpenWinMenu()
    {
        isPause = true;
        winMenu.SetActive(true);
    }

    public void CloseWinMenu()
    {
        isPause = false;
        winMenu.SetActive(false);
    }

    public void OpenLoseMenu()
    {
        isPause = true;
        loseMenu.SetActive(true);
    }

    public void CloseLoseMenu()
    {
        isPause = false;
        loseMenu.SetActive(false);
    }

}
