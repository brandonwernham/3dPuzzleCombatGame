using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour
{
    public string mainMenu;
    public Button su1;
    public Button su2;
    public Button pu1;
    public Button pu2;
    public AudioSource soundManager;
    public AudioClip hoverSound;

    void Update()
    {
        if (CoinCount.coinCount < 10)
        {
            su1.interactable = false;
            pu1.interactable = false;
        }

        if (CoinCount.coinCount < 30)
        {
            su2.interactable = false;
            pu2.interactable = false;
        }

        if (UpgradeManager.speedUpgrade1)
        {
            su1.GetComponent<Image>().color = Color.green;
            su1.interactable = false;
        }
        if (UpgradeManager.speedUpgrade2)
        {
            su2.GetComponent<Image>().color = Color.green;
            su2.interactable = false;
        }
        if (UpgradeManager.powerUpgrade1)
        {
            pu1.GetComponent<Image>().color = Color.green;
            pu1.interactable = false;
        }
        if (UpgradeManager.powerUpgrade2)
        {
            pu2.GetComponent<Image>().color = Color.green;
            pu2.interactable = false;
        }
    }

    public void HoverSound()
    {
        soundManager.PlayOneShot(hoverSound);
    }

    public void SU1()
    {
        UpgradeManager.speedUpgrade1 = true;
        CoinCount.coinCount -= 10;
    }

    public void SU2()
    {
        UpgradeManager.speedUpgrade2 = true;
        CoinCount.coinCount -= 30;
    }

    public void PU1()
    {
        UpgradeManager.powerUpgrade1 = true;
        CoinCount.coinCount -= 10;
    }

    public void PU2()
    {
        UpgradeManager.powerUpgrade2 = true;
        CoinCount.coinCount -= 30;
    }

    public void Back()
    {
        SceneManager.LoadScene(mainMenu);
    }
}
