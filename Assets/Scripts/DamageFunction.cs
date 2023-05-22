using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Functions/Damage")]
public class DamageFunction : ScriptableObject
{
    public bool TakeDamage(Stats target, Stats self, float damage)
    {
        if(target.CurrentHP - damage < 0)
        {
            return true;
        }
        else
        {
            target.CurrentHP -= damage;
            return false;
        }
    }
}
