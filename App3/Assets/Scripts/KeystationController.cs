using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeystationController : MonoBehaviour
{
    public ButtonController button1;
    public ButtonController button2;
    public ButtonController button3;
    public int whichStationHasKey;

    void Start()
    {
        whichStationHasKey = Random.Range(1, 4);
        
        if(whichStationHasKey == 1)
        {
            button1.hasKey = true;
        }
        if (whichStationHasKey == 2)
        {
            button2.hasKey = true;
        }
        if (whichStationHasKey == 3)
        {
            button3.hasKey = true;
        }
    }
}
