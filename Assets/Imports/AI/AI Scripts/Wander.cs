using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName ="AI/CreatureBehaviors/Wander")]
public class Wander : CreatureBehavior
{
    [SerializeField] private float range;
    [SerializeField] private PathfindingAction randomDestination;
    private int maxIterations = 100;
    public override void Act(CreatureData self)
    {
        Debug.Log($"{self.CreatureName} wanders");
        Vector3 pos = self.CreatureReference.transform.position;
        GoToDestination(self, pos, range, out Vector3 destination, 0);
        
    }

    private bool GoToDestination(CreatureData self ,Vector3 pos, float range, out Vector3 destination, int iteration)
    {
        if(iteration <= maxIterations)
        {
            if (randomDestination.Check(pos, range, out destination))
            {
                Actions[0].Action(self, destination);
                return true;
            }
            else
            {
                iteration++;
                return GoToDestination(self, pos, range, out destination, iteration);
            }
        }
        else
        {
            destination = Vector3.zero;
            return false;
        }
    }
}
