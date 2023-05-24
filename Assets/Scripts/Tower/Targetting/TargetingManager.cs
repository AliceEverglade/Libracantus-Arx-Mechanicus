using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Targeting/Manager")]
public class TargetingManager : ScriptableObject
{
    [SerializeField] private List<Targeting> targetingSystemList;

    public Targeting GetTargetingSystem(string name)
    {
        foreach (Targeting t in targetingSystemList)
        {
            if (t.name == name)
            {
                return t;
            }
        }
        return null;
    }
}
