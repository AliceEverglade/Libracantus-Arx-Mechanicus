using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Targeting/Furthest")]
public class FurthestTarget : Targeting
{
    public override List<Stats> GetTargets(Stats self, List<Stats> input)
    {
        List<Stats> output = new List<Stats>();
        Stats highest = null;
        Vector3 selfPos = self.transform.position;
        foreach (Stats s in input)
        {
            if (highest == null ||
                Vector3.Distance(highest.transform.position, selfPos) < Vector3.Distance(s.transform.position, selfPos))
            {
                highest = s;
            }
        }
        output.Add(highest);
        return output;
    }
}
