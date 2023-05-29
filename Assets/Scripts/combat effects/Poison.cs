using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effects/Poison")]
public class Poison : OverTimeEffect
{
    public override void Activate(Stats target, Stats self, float potency, float duration)
    {
        float timer = duration;
        target.PoisonActivation(potency, duration, timer);
    }
}
