using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureStats : Stats
{
    public float movementSpeed;
    public float movementSpeedMultiplier;




    public override IEnumerator Slow(float potency, float duration, float tickSpeed, float timer)
    {
        if (potency < movementSpeedMultiplier)
        {
            movementSpeedMultiplier = potency;
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
