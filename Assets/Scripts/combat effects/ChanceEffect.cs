using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effects/ChanceEffect")]
public class ChanceEffect : OverTimeEffect
{
    public float chance;
    public OverTimeEffect effect;
    public override void Activate(Stats target, Stats self, float potency, float duration)
    {
        if (Random.Range(1, 101) > chance)
        {
            effect.Activate(target, self, potency, duration);
        }
    }

}
