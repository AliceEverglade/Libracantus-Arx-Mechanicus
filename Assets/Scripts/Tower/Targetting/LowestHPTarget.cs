using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Targeting/LowestHP")]
public class LowestHPTarget : Targeting
{
    public override List<Stats> GetTargets(Stats self, List<Stats> input)
    {
        List<Stats> output = new List<Stats>();
        Stats lowest = null;

        foreach (Stats s in input)
        {
            if (lowest == null ||
                lowest.CurrentHP > s.CurrentHP)
            {
                lowest = s;
            }
        }
        output.Add(lowest);
        return output;
    }
}
