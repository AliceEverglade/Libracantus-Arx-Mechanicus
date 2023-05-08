using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PathfindingAction : ScriptableObject
{
    //known destination
    public virtual bool Check(Vector3 input, out Vector3 output)
    { Debug.LogWarning("this Pathfinding Action does not have a matching Check() method"); output = Vector3.forward; return false; }

    //random destination
    public virtual bool Check(Vector3 input, float range, out Vector3 output) 
    { Debug.LogWarning("this Pathfinding Action does not have a matching Check() method");output = Vector3.forward; return false; }

    //weighted random destination
    public virtual bool Check(Vector3 input, float range,int sampleSize, List<WeightedPos> weights, out Vector3 output)
    { Debug.LogWarning("this Pathfinding Action does not have a matching Check() method"); output = Vector3.forward; return false; }

}
