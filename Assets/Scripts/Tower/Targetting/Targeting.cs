using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Targeting : ScriptableObject
{
    public abstract List<Stats> GetTargets(Stats self,List<Stats> input);
}
