using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerStats : Stats
{
    public float Range;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range);
    }


    public override IEnumerator Slow(float potency, float duration, float tickSpeed, float timer)
    {
        if(potency < SpeedMultiplier)
        {
            SpeedMultiplier = potency;
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
