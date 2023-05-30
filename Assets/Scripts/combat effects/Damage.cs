using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effects/Damage")]
public class Damage : CombatEffect
{
    public override void Activate(Stats target, Stats self, float damage)
    {
        Debug.Log($"{self.name} dealt {damage} damage to {target.name}");
        target.CurrentHP -= damage;
    }
}
