using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effects/Heal")]
public class Heal : CombatEffect
{
    public override void Activate(Stats target, Stats self, float damage)
    {
        target.CurrentHP += damage;
    }
}
