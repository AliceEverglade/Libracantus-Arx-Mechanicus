using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerLevel : MonoBehaviour
{
    int levelCount = 0;

    public enum TowerChoice
    {
        Fire,
        Ice,
        Poison,
        Magic,
        Heal
    }

    [SerializeField]
    private TowerChoice selectedTower;

    public float TowerCost;
    public float AddPrice;
    public float MultiplyPrice;

    public int MaxLevel;
    public static bool DisableUpgrading = false;

    public TextMeshProUGUI levelNumber;
    public TextMeshProUGUI priceNumber;
    public GameObject MaxLevelText;
    public GameObject UpgradeUI;

    void Start()
    {
        priceNumber.text = TowerCost.ToString();
    }

    public void BuyUpgrade()
    {
        if(Coins.countCoins >= TowerCost && DisableUpgrading == false)
        {
            levelCount++;
            levelNumber.text = levelCount.ToString();
            Coins.countCoins -= TowerCost;
            if(AddPrice != 0)
            {
                TowerCost = TowerCost += AddPrice;
            }
            if(MultiplyPrice != 0)
            {
                TowerCost = TowerCost * MultiplyPrice;
            }
            priceNumber.text = TowerCost.ToString();
        }
        if(levelCount == MaxLevel)
        {
            DisableUpgrading = true;
            MaxLevelText.SetActive(true);
            UpgradeUI.SetActive(false);
        }

        if(selectedTower == TowerChoice.Fire)
        {
            //make a change in this script or call a function here for a diferent upgrade script that needs to be attached to the tower.
        }
        if (selectedTower == TowerChoice.Ice)
        {
            //make a change in this script or call a function here for a diferent upgrade script that needs to be attached to the tower.
        }
        if (selectedTower == TowerChoice.Poison)
        {
            //make a change in this script or call a function here for a diferent upgrade script that needs to be attached to the tower.
        }
        if (selectedTower == TowerChoice.Magic)
        {
            //make a change in this script or call a function here for a diferent upgrade script that needs to be attached to the tower.
        }
        if (selectedTower == TowerChoice.Heal)
        {
            //make a change in this script or call a function here for a diferent upgrade script that needs to be attached to the tower.
        }
    }
}
