using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Stats : MonoBehaviour
{
    public float MaxHP;
    public float CurrentHP;

    [Range(0.1f, 100f)] // min and max attacks per second
    public float Speed;
    public float SpeedMultiplier;
    public List<AttackData> OnHitEffects;

    [SerializeField] private TargetingManager targetingManager;
    public Targeting targetingSystem;
    [SerializeField] private AttackPriorities attackPriority;
    public AttackPriorities AttackPriority
    {
        get => attackPriority;
        set
        {
            if (targetingManager.GetTargetingSystem(value) != null)
            {
                targetingSystem = targetingManager.GetTargetingSystem(value);
            }
            else
            {
                Debug.Log("targetting system not found");
            }
            attackPriority = value;
        }
    }

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


    public void CallOnHitEffects(Stats target)
    {
        foreach(AttackData data in OnHitEffects)
        {
            data.Effect.Activate(target, this, data.Potency);
        }
    }
    #region CombatEffects
    public void SlowActivation(float potency, float duration, float tickSpeed)
    {
        float timer = duration;
        StartCoroutine(Slow(potency, duration, tickSpeed, timer));
    }
    public IEnumerator Slow(float potency, float duration, float tickSpeed, float timer)
    {
        if (potency < SpeedMultiplier)
        {
            SpeedMultiplier = potency;
        }
        timer -= tickSpeed;
        yield return new WaitForSeconds(tickSpeed / 1000);
        if (timer > 0)
        {
            Slow(potency, duration, tickSpeed, timer);
        }
        else
        {
            SpeedMultiplier = 1;
            yield break;
        }
    }


    public void BurnActivation(float potency, float duration, float tickSpeed)
    {
        float timer = duration;
        StartCoroutine(Burn(potency, duration, tickSpeed, timer));
    }

    public IEnumerator Burn(float potency, float duration, float tickSpeed, float timer)
    {
        CurrentHP -= potency;
        timer -= tickSpeed;
        yield return new WaitForSeconds(tickSpeed/1000);
        if(timer > 0)
        {
            Burn(potency, duration, tickSpeed, timer);
        }
        else
        {
            yield break;
        }
    }

    public void PoisonActivation(float potency, float duration, float tickSpeed)
    {
        float timer = duration;
        StartCoroutine(Poison(potency, duration, tickSpeed, timer));
    }

    public IEnumerator Poison(float potency, float duration, float tickSpeed, float timer)
    {
        CurrentHP *= (100-potency) / 100;
        timer -= tickSpeed;
        yield return new WaitForSeconds(tickSpeed/1000);
        if (timer > 0)
        {
            Poison(potency, duration, tickSpeed, timer);
        }
        else
        {
            yield break;
        }
    }
    #endregion


    private void OnValidate()
    {
        if(targetingManager != null)
        {
            targetingSystem = targetingManager.GetTargetingSystem(attackPriority);
        }
    }
}

[Serializable]
public class AttackData
{
    public CombatEffect Effect;
    public float Potency;
    public float Duration;
}
