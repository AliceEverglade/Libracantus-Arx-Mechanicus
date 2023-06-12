using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PotionEffect/HastePotion")]
public class HastePotion : PotionEffect
{
    public override void Activate()
    {
        Debug.Log("Haste potion effect goes here.");
    }
}
