using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName ="AI/Actions/MoveTo")]
public class MoveTo : BehaviorAction
{
    public override void Action(CreatureData self, Vector3 target)
    {
        Debug.Log($"{self.CreatureName} moves to {target}");
        if (self.CreatureReference != null)
        {
            Debug.Log("reference found");
            self.CreatureReference.GetComponent<NavMeshAgent>().destination = target;
        }
        
    }
}
