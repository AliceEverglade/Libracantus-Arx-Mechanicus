using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CreatureStats
{
    public static event Action<GameObject> onReferenceSet;

    public static event Action<PlayerStats> onPlayerStatsSet;

    public GameObject PlayerObj;

    private void Start()
    {
        PlayerObj = this.gameObject;
        onReferenceSet(this.gameObject);
        onPlayerStatsSet(this);
    }
}
