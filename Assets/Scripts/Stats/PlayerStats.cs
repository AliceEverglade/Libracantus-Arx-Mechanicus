using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CreatureStats
{
    public static event Action<GameObject> onReferenceSet;

    public static event Action<PlayerStats> onPlayerStatsSet;

    private void Start()
    {
        onReferenceSet(this.gameObject);
        //onPlayerStatsSet(this);
    }
}
