using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CreatureData : ScriptableObject
{
    [Header("Base")]
    public string CreatureName;
    public GameObject Prefab;
    public GameObject CreatureReference;

    [Header("AI")]
    public List<CreatureBehavior> Behaviors;
    public CreatureBehavior CurrentBehavior;

    public abstract void SetData();

    public void Spawn(Vector3 pos)
    {
        CreatureReference = Instantiate(Prefab,pos, Quaternion.identity);
        SetData();
    }
    public void ActivateBehavior()
    {
        CurrentBehavior.Act(this);
    }
}
