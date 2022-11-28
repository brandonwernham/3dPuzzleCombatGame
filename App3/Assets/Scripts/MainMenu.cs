using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string gameMap;
    public string upgradeMenu;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 1f;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(gameMap);
    }

    public void UpgradeMenu()
    {
        SceneManager.LoadScene(upgradeMenu);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
