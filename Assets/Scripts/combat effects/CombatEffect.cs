using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CombatEffect : ScriptableObject
{
    public virtual void Activate(Stats target, Stats self, float potency) { }
    public virtual void Activate(Stats target, Stats self, float potency, float duration) { }
}
