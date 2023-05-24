using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Stats : MonoBehaviour
{
    public float MaxHP;
    public float CurrentHP;
    public float Speed;
    public float SpeedMultiplier;

    #region CombatEffects
    public void SlowActivation(float potency, float duration, float tickSpeed)
    {
        float timer = duration;
        StartCoroutine(Slow(potency, duration, tickSpeed, timer));
    }
    public abstract IEnumerator Slow(float potency, float duration, float tickSpeed, float timer);
    public void BurnActivation(float potency, float duration, float tickSpeed)
    {
        float timer = duration;
    }

    public IEnumerator Burn(float potency, float duration, float tickSpeed, float timer)
    {
        CurrentHP -= potency;
        timer -= tickSpeed;
        yield return new WaitForSeconds(tickSpeed);
        if(timer > 0)
        {
            Burn(potency, duration, tickSpeed, timer);
        }
        else
        {
            yield break;
        }
    }
    #endregion
}
