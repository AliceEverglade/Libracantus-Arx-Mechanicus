using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerStatBuff : ScriptableObject
{
    public abstract void AddStat(PlayerStats stats, float potency);

    public abstract void RemoveStat(PlayerStats stats, float potency);
}
