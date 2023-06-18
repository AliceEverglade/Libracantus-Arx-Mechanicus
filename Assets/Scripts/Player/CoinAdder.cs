using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAdder : MonoBehaviour
{
    [SerializeField] private PlayerInventory inventory;

    private void OnEnable()
    {
        OnDeath.OnCreatureDeath += AddCoins;
    }

    private void OnDisable()
    {
        OnDeath.OnCreatureDeath -= AddCoins;
    }

    void AddCoins(Stats stats, GameObject deadTarget)
    {
        inventory.AddCoins(stats.Value);
    }
}
