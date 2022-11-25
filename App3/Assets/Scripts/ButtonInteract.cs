using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ButtonInteract : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;
    public TextMeshProUGUI buttonText;
    public bool buttonPressed;
    public bool buttonAlreadySearched;

    void Update()
    {
        if (isInRange)
        {
            buttonText.text = "Press E to search for key";
            if (Input.GetKeyDown(interactKey))
            {
                isInRange = false;
                interactAction.Invoke();
                buttonText.text = "";
                buttonPressed = true;
                buttonAlreadySearched = true;
            }
        }
        else
        {
            buttonText.text = "";
        }

        if (buttonPressed)
        {
            isInRange = false;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player") && !buttonPressed)
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            isInRange = false;
        }
    }
}
