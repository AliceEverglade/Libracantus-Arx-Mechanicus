using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CreatureBehavior : ScriptableObject
{
    public List<BehaviorAction> Actions;
    public virtual void Act(CreatureData self) 
    {
        Debug.LogWarning("this behavior does not have a matching Act() method");
    }
}
