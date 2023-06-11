using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Data/RoomLibrary")]
public class RoomLibrary : ScriptableObject
{
    public RoomData Entrance;
    public RoomData Exit;
    public RoomData Wall;
    public RoomData GenericRoom;
    [Range(0.01f, 1f)]
    public float WeightValue;
    public List<RoomData> RoomDataList;
    public int RoomCount;

    private void OnValidate()
    {
        foreach (RoomData data in RoomDataList)
        {
            data.Name = data.Prefab.name;
        }
    }

    public RoomData GetRoom(List<RoomData.OpeningDirections> directions)
    {
        List<RoomData> matchingRooms = new List<RoomData>();
        float weightCounter = 0;
        float roomWeight = 0;
        foreach (RoomData data in RoomDataList)
        {
            foreach (RoomData.OpeningDirections dir in directions)
            {
                if (data.RoomOpenings.Contains(dir))
                {
                    matchingRooms.Add(data);
                }
            }
        }
        foreach (RoomData data in matchingRooms)
        {
            weightCounter += data.SpawningWeight * Mathf.Pow(data.Modifier,RoomCount) * WeightValue;
        }
        roomWeight = UnityEngine.Random.Range(0, weightCounter);
        foreach (RoomData data in matchingRooms)
        {
            if (data.SpawningWeight * WeightValue >= roomWeight)
            {
                return data;
            }
            else
            {
                roomWeight -= data.SpawningWeight * Mathf.Pow(data.Modifier, RoomCount) * WeightValue;
            }
        }
        return GenericRoom;
    }

    public void StartGeneration(GameObject target)
    {
        GameObject startRoom = Instantiate(Entrance.Prefab, target.transform.position, Quaternion.identity);
        startRoom.GetComponent<RoomHolder>().SetRoomData(Entrance);
    }
}

[Serializable]
public class RoomData
{
    [HideInInspector]
    public string Name;
    
    public List<OpeningDirections> RoomOpenings;
    public float SpawningWeight;
    [Range(-50,50)]
    public float WeightModifier = 0;
    public float Modifier => (100 + WeightModifier) / 100;
    public GameObject Prefab;
    public enum OpeningDirections
    {
        North,
        East,
        South,
        West
    }
}
