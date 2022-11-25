using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonController : MonoBehaviour
{
    public bool isPressed;
    public bool hasKey;
    public bool isCountingDown;
    public float countdown;
    public TextMeshProUGUI countdownText;
    public GameObject gate1;
    public GameObject gate2;
    public Material red;
    public GameObject greenLight;
    public ButtonInteract otherButton1;
    public ButtonInteract otherButton2;
    public EnemySpawn spawn1;
    public EnemySpawn spawn2;
    public EnemySpawn spawn3;
    public EnemySpawn spawn4;
    public float rapidSpawn;

    void Update()
    {
        if (isCountingDown)
        {
            spawn1.startTime = rapidSpawn;
            spawn2.startTime = rapidSpawn;
            spawn3.startTime = rapidSpawn;
            spawn4.startTime = rapidSpawn;

            otherButton1.buttonPressed = true;
            otherButton2.buttonPressed = true;

            if (countdown > 0)
            {
                countdown -= Time.deltaTime;
            }
            double temp = System.Math.Round(countdown, 0);
            countdownText.text = temp.ToString();
            if (countdown <= 0)
            {
                isCountingDown = false;
                CheckForKey();
            }
        }
    }

    public void PressButton()
    {
        if (!isPressed)
        {
            isPressed = true;
            Countdown();
        }
    }

    public void Countdown()
    {
        isCountingDown = true;
    }

    public void CheckForKey()
    {
        isCountingDown = false;

        spawn1.startTime = 10f;
        spawn2.startTime = 10f;
        spawn3.startTime = 10f;
        spawn4.startTime = 10f;

        if (!otherButton1.buttonAlreadySearched)
        {
            otherButton1.buttonPressed = false;
        }
        if (!otherButton2.buttonAlreadySearched)
        {
            otherButton2.buttonPressed = false;
        }

        if (hasKey)
        {
            countdownText.text = "Key found! The doors have opened!";
            Destroy(gate1);
            Destroy(gate2); 
        }
        else
        {
            countdownText.text = "Key not found!";
            gameObject.GetComponent<MeshRenderer>().material = red;
            Destroy(greenLight);
        }
    }
}
