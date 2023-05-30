using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Effects/Burn")]
public class Burn : OverTimeEffect
{
    public override void Activate(Stats target, Stats self, float potency, float duration)
    {
        Debug.Log($"{self.name} burns {target.name}, {potency} damage per {TickSpeed}ms for {duration} seconds");
        float timer = duration;
        target.BurnActivation(potency, duration, timer);
    }
}
