using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerStats : Stats
{

    [SerializeField] private TargetingManager targetingManager;
    [SerializeField] private Targeting targetingSystem;
    [SerializeField] private AttackPriorities attackPriority;
    public AttackPriorities AttackPriority
    {
        get => attackPriority;
        set
        {
            if(targetingManager.GetTargetingSystem(value.ToString()) != null)
            {
                targetingSystem = targetingManager.GetTargetingSystem(value.ToString());
            }
            else
            {
                Debug.Log("targetting system not found");
            }
            attackPriority = value;
        }
    }
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
