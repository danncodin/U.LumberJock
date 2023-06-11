using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;
    public GameObject creditsMenuUI;
    public GameObject pauseButton;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }else
            {
                Pause();
            }
        }
    }
    public void PauseButtonPressed()
    {
        if (GameIsPaused)
        {
            Resume();
        }else
        {
            Pause();
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        FindObjectOfType<AudioManager>().Play("Interação com o Menu");
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        FindObjectOfType<AudioManager>().Play("Interação com o Menu");
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void GameOptions()
    {
        pauseMenuUI.SetActive(false);
        FindObjectOfType<AudioManager>().Play("Interação com o Menu");
        optionsMenuUI.SetActive(true);
    }
    public void OptionsBackButton()
    {
        optionsMenuUI.SetActive(false);
        FindObjectOfType<AudioManager>().Play("Interação com o Menu");
        pauseMenuUI.SetActive(true);
    }
    public void Credits()
    {
        pauseMenuUI.SetActive(false);
        FindObjectOfType<AudioManager>().Play("Interação com o Menu");
        creditsMenuUI.SetActive(true);
    }
    public void CreditsBackButton()
    {
        creditsMenuUI.SetActive(false);
        FindObjectOfType<AudioManager>().Play("Interação com o Menu");
        pauseMenuUI.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Quiting Game...");
        FindObjectOfType<AudioManager>().Play("Interação com o Menu");
        Application.Quit();
    }
}
