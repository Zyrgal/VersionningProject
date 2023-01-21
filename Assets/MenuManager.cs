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
            if (isPause && canPause)
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
        isPause = false;
        Time.timeScale = 0;
        OpenPauseMenu();
    }

    public void UI_Resume()
    {
        isPause = true;
        Time.timeScale = 1;
        ClosePauseMenu();
    }

    public void OpenPauseMenu()
    {
        pauseMenu.SetActive(true);
    }

    public void ClosePauseMenu()
    {
        pauseMenu.SetActive(false);
    }

    public void OpenWinMenu()
    {
        winMenu.SetActive(true);
    }

    public void CloseWinMenu()
    {
        winMenu.SetActive(false);
    }

    public void OpenLoseMenu()
    {
        loseMenu.SetActive(true);
    }

    public void CloseLoseMenu()
    {
        loseMenu.SetActive(false);
    }

}
