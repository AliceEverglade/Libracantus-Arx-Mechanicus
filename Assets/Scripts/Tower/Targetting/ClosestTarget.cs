using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Targeting/Closest")]
public class ClosestTarget : Targeting
{
    public override List<Stats> GetTargets(Stats self, List<Stats> input)
    {
        List<Stats> output = new List<Stats>();
        Stats lowest = null;
        Vector3 selfPos = self.transform.position;
        foreach (Stats s in input)
        {
            if( lowest == null || 
                Vector3.Distance(lowest.transform.position, selfPos) > Vector3.Distance(s.transform.position,selfPos))
            {
                lowest = s;
            }
        }
        output.Add(lowest);
        return output;
    }
}
