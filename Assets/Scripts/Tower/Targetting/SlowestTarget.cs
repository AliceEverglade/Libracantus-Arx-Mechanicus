using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Targeting/Slowest")]
public class SlowestTarget : Targeting
{
    public override List<Stats> GetTargets(Stats self, List<Stats> input)
    {
        List<Stats> output = new List<Stats>();
        Stats lowest = null;

        foreach (Stats s in input)
        {
            if (lowest == null ||
                lowest.Speed > s.Speed)
            {
                lowest = s;
            }
        }
        output.Add(lowest);
        return output;
    }
}
