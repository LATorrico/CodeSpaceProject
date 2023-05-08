using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject player;
    
    public static bool gameIsPaused = false;

    public GameObject pauseMenu;
    public GameObject missionPanel;
    public GameObject missionCompletePanel;
    public GameObject controlsPanel;

    private void Start()
    {
        Time.timeScale = 0f;
        player.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        player.SetActive(true);
    }

    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        player.SetActive(false);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenuScene");
    }

    public void QuitGame()
    {
        Debug.Log("Salir");
        Application.Quit();
    }

    public void StartMission()
    {
        Time.timeScale = 1f;
        missionPanel.SetActive(false);
        player.SetActive(true);
    }

    public void ControlsPanelOn()
    {
        controlsPanel.SetActive(true);
    }

    public void ControlsPanelOff()
    {
        controlsPanel.SetActive(false);
    }
}