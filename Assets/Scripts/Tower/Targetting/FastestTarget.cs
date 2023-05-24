using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Targeting/Fastest")]
public class FastestTarget : Targeting
{
    public override List<Stats> GetTargets(Stats self, List<Stats> input)
    {
        List<Stats> output = new List<Stats>();
        Stats highest = null;
        
        foreach (Stats s in input)
        {
            if( highest == null || 
                highest.speed < s.speed)
            {
                highest = s;
            }
        }
        output.Add(highest);
        return output;
    }
}
