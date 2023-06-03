using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLibrary : ScriptableObject
{
    public RoomData Entrance;
    public RoomData Exit;
    public List<RoomData> RoomDataList;
}

public class RoomData
{
    public List<OpeningDirections> RoomOpenings;
    public float SpawningWeight;
    public GameObject Prefab;
    public enum OpeningDirections
    {
        North,
        East,
        South,
        West
    }
}
