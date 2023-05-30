using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effects/Heal")]
public class Heal : CombatEffect
{
    public override void Activate(Stats target, Stats self, float healing)
    {
        Debug.Log($"{self.name} heals {target.name} for {healing} hp");
        if(target.CurrentHP + healing <= target.MaxHP)
        {
            target.CurrentHP += healing;
        }
        else
        {
            target.CurrentHP = target.MaxHP;
        }
        
    }
}
