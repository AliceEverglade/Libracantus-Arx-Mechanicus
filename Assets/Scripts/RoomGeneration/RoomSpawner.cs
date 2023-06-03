using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    [SerializeField] private RoomData.OpeningDirections spawnDirection;

    private void Update()
    {
        switch (spawnDirection)
        {
            case RoomData.OpeningDirections.North:
                //spawn room with South opening
                break;
            case RoomData.OpeningDirections.East:
                //spawn room with West opening
                break;
            case RoomData.OpeningDirections.South:
                //spawn room with North opening
                break;
            case RoomData.OpeningDirections.West:
                //spawn room with East opening
                break;
        }
    }
}
