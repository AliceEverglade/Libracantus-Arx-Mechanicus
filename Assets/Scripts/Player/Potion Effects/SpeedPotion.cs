using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PotionEffect/SpeedPotion")]
public class SpeedPotion : PotionEffect
{
    public override void Activate(PlayerStats stats, float potency, float duration)
    {
        Debug.Log("Speed potion effect goes here.");
    }
}
