using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effects/Slow")]
public class Slow : OverTimeEffect
{
    public override void Activate(Stats target, Stats self, float potency, float duration)
    {
        Debug.Log($"{self.name} slowed {target.name}, {potency}% per {TickSpeed}ms for {duration} seconds");
        float timer = duration;
        target.SlowActivation(potency, duration, timer);
    }
}
