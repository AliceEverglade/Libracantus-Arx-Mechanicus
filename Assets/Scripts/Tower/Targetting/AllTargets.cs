using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Targeting/All")]
public class AllTargets : Targeting
{
    public override List<Stats> GetTargets(Stats self, List<Stats> input)
    {
        return input;
    }
}
