using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct WeightedPos
{
    public WeightedPos(Vector3 pos, float weight)
    {
        Pos = pos;
        Weight = weight;
    }
    public Vector3 Pos { get; }
    public float Weight { get; }
}

public class Struct
{
    
}
