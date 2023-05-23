using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerStats : Stats
{
    public float attackSpeed;
    public float attackSpeedMultiplier;
    public AttackPriorities AttackPriority;
    public float Range;

    public enum AttackPriorities
    {
        LowestHP,
        HighestHP,
        Closest,
        Furthest,
        Fastest,
        Slowest,
        All
    }



    public override IEnumerator Slow(float potency, float duration, float tickSpeed, float timer)
    {
        if(potency < attackSpeedMultiplier)
        {
            attackSpeedMultiplier = potency;
        }
        timer -= tickSpeed;
        yield return new WaitForSeconds(tickSpeed);
        if (timer > 0)
        {
            Slow(potency, duration, tickSpeed, timer);
        }
        else
        {
            yield break;
        }
    }
}
