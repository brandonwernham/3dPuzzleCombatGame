using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RePosition : MonoBehaviour
{
    void Start()
    {
        CoinCount.coinsThisGame = 0;
    }

    void OnTriggerEnter(Collider col)
    {
        if (!col.gameObject.CompareTag("Enemy"))
        {
            int newX = Random.Range(-23, 23);
            int newZ = Random.Range(-23, 23);
            gameObject.transform.position = new Vector3(newX, 1, newZ);
        }

        if (col.gameObject.CompareTag("Player"))
        {
            CoinCount.coinCount += 1;
            CoinCount.coinsThisGame += 1;
            Debug.Log("Coins: " + CoinCount.coinCount);
            Debug.Log("Coins this game: " + CoinCount.coinsThisGame);
        }
    }
}
