using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Effects/Burn")]
public class Burn : OverTimeEffect
{
    public override void Activate(Stats target, Stats self, float potency, float duration)
    {
        float timer = duration;
        target.BurnActivation(potency, duration, timer);
    }
}
