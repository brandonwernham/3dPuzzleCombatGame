using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCountText : MonoBehaviour
{
    public TextMeshProUGUI countText;

    void Update()
    {
        countText.text = CoinCount.coinCount.ToString();
    }
}
