using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BehaviorAction : ScriptableObject
{
    public virtual void Action(CreatureData self)
    {
        Debug.LogWarning("this action does not have a matching Action() method");
    }
    public virtual void Action(CreatureData self, Vector3 target)
    {
        Debug.LogWarning("this action does not have a matching Action() method");
    }
}
