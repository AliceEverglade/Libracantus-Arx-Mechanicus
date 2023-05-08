using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName ="AI/PathfindingActions/CheckRandomDestination")]
public class CheckRandomDestination : PathfindingAction
{
    public override bool Check(Vector3 input, float range, out Vector3 output)
    {
        Vector3 randomPoint = input + Random.insideUnitSphere * range;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            output = hit.position;
            return true;
        }
        output = Vector3.zero;
        return false;
    }
}
