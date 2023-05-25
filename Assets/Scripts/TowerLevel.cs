using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerLevel : MonoBehaviour
{
    public TextMeshProUGUI level;
    int levelCount = 0;
    public int TowerCost = 150;

    public void BuyUpgrade()
    {
        if(Coins.countCoins >= TowerCost)
        {
            levelCount++;
            level.text = levelCount.ToString();
            Coins.countCoins -= TowerCost;
        }
    }
}
