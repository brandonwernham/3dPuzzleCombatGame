using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseUI;
    public PlayerCamera playerCam;
    public GunController gun;
    public string mainMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
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
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        playerCam.isPaused = false;
        gun.isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    void Pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        playerCam.isPaused = true;
        gun.isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        isPaused = false;
        playerCam.isPaused = false;
        gun.isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Application.LoadLevel(Application.loadedLevel);

        CoinCount.coinCount -= CoinCount.coinsThisGame;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);

        CoinCount.coinCount -= CoinCount.coinsThisGame;
    }
}
