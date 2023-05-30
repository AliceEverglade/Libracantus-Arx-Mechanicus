using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Targeting/Manager")]
public class TargetingManager : ScriptableObject
{
    [SerializeField] private List<TargetingSystemData> targetingSystemList;

    public Targeting GetTargetingSystem(Stats.AttackPriorities priority)
    {
        foreach (TargetingSystemData t in targetingSystemList)
        {
            if (t.priority == priority)
            {
                return t.system;
            }
        }
        return null;
    }
}


[Serializable]
public class TargetingSystemData
{
    public Targeting system;
    public Stats.AttackPriorities priority;
}

