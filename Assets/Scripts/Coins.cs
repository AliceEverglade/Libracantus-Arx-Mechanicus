using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coins : MonoBehaviour
{
    public TextMeshProUGUI coins;
    [SerializeField] private PlayerInventory Coin;

    private void Update()
    {
        coins.text = Coin.Coins.ToString();
        if(Coin.Coins <= 0)
        {
            Coin.Coins = 0;
        }
    }
}
