using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerStats : Stats
{
    public float Range;
    public float AttackSpeedCounter;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range);
    } 
}
