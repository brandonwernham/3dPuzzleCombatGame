using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCoins : MonoBehaviour
{
    public GameObject coin;
    public int numOfCoins;
    void Start()
    {
        int[] xLocation = new int[numOfCoins];
        int[] zLocation = new int[numOfCoins];
        for (int i = 0; i < numOfCoins; i++)
        {
            xLocation[i] = Random.Range(-23, 23);
            zLocation[i] = Random.Range(-23, 23);
            Instantiate(coin, new Vector3(xLocation[i], 1, zLocation[i]), Quaternion.Euler(0, 90, 0));
        }
    }
}
