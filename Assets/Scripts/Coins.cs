using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coins : MonoBehaviour
{
    public TextMeshProUGUI coins;
    public static int countCoins = 1000;

    private void Update()
    {
        coins.text = countCoins.ToString();
        if(countCoins <= 0)
        {
            countCoins = 0;
        }
    }
}
