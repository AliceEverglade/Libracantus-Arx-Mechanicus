using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PotionEffect/HealthPotion")]
public class HealthPotion : PotionEffect
{
    public override void Activate(PlayerStats stats, float potency)
    {
        Debug.Log("Health potion effect goes here.");
    }
}
