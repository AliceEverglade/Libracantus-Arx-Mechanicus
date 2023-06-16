using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TowerLevel1 : MonoBehaviour
{
    int levelCount = 1;

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

    [SerializeField] private TowerStats stats;

    void Start()
    {
        priceNumber.text = TowerCost.ToString();
    }

    public void BuyUpgrade()
    {
        if (Coins.countCoins >= TowerCost && DisableUpgrading == false)
        {
            levelCount++;
            levelNumber.text = levelCount.ToString();
            Coins.countCoins -= TowerCost;
            if (AddPrice != 0)
            {
                TowerCost = TowerCost += AddPrice;
            }
            if (MultiplyPrice != 0)
            {
                TowerCost = TowerCost * MultiplyPrice;
            }
            priceNumber.text = TowerCost.ToString();

            if (selectedTower == TowerChoice.Fire)
            {
                stats.StrengthMultiplier += 0.1f;
                stats.Range += 0.25f;
                stats.Speed += 0.25f;
                stats.MaxHP += 10;
            }
            if (selectedTower == TowerChoice.Ice)
            {
                stats.StrengthMultiplier += 0.1f;
                stats.Range += 0.4f;
                stats.Speed += 0.15f;
                stats.MaxHP += 10;
            }
            if (selectedTower == TowerChoice.Poison)
            {
                stats.StrengthMultiplier += 0.05f;
                stats.Range += 0.25f;
                stats.MaxHP += 10;
            }
            if (selectedTower == TowerChoice.Magic)
            {
                stats.StrengthMultiplier += 0.2f;
                stats.Range += 0.4f;
                stats.Speed += 0.25f;
                stats.MaxHP += 20;
            }
            if (selectedTower == TowerChoice.Heal)
            {
                stats.StrengthMultiplier += 0.1f;
                stats.Range += 0.1f;
                stats.Speed += 0.1f;
                stats.MaxHP += 30;
            }
        }
        if (levelCount == MaxLevel)
        {
            DisableUpgrading = true;
            MaxLevelText.SetActive(true);
            UpgradeUI.SetActive(false);
        }
    }
}
