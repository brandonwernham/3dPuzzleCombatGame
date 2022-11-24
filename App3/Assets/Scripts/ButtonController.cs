using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public bool isPressed;
    public bool hasKey;
    public bool isCountingDown;
    public float countdown;
    public Text countdownText;
    public GameObject gate1;
    public GameObject gate2;

    void Update()
    {
        if (isCountingDown)
        {
            if (countdown > 0)
            {
                countdown -= Time.deltaTime;
            }
            double temp = System.Math.Round(countdown, 2);
            countdownText.text = temp.ToString();
            if (countdown <= 0)
            {
                isCountingDown = false;
                // something here to take away the count text
                CheckForKey();
            }
        }
    }

    public void PressButton()
    {
        if (!isPressed)
        {
            isPressed = true;
            Debug.Log("The button was pressed");
            Countdown();
        }
    }

    public void Countdown()
    {
        isCountingDown = true;
    }

    public void CheckForKey()
    {
        if (hasKey)
        {
            Destroy(gate1);
            Destroy(gate2); 
        }
    }
}
