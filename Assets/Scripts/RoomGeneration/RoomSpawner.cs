using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    [SerializeField] private RoomData.OpeningDirections spawnDirection;
    private RoomLibrary library;
    private StartRun libraryHolder;
    private RoomData roomData;
    private bool spawned = false;

    public static event Action<GameObject> onSpawnRoom;

    private void Start()
    {
        libraryHolder = GameObject.Find("Start").GetComponent<StartRun>();
        library = libraryHolder.library;
        Invoke("Spawn", 0.1f);
    }
    private void Spawn()
    {
        if (!spawned && libraryHolder.library.RoomCount < libraryHolder.RoomCap)
        {
            List<RoomData.OpeningDirections> dirs = new List<RoomData.OpeningDirections>();
            switch (spawnDirection)
            {
                case RoomData.OpeningDirections.North:
                    dirs.Add(RoomData.OpeningDirections.South);
                    break;
                case RoomData.OpeningDirections.East:
                    dirs.Add(RoomData.OpeningDirections.West);
                    break;
                case RoomData.OpeningDirections.South:
                    dirs.Add(RoomData.OpeningDirections.North);
                    break;
                case RoomData.OpeningDirections.West:
                    dirs.Add(RoomData.OpeningDirections.East);
                    break;
            }
            roomData = library.GetRoom(dirs);
            GameObject room = Instantiate(roomData.Prefab, transform.position, Quaternion.identity);
            room.GetComponent<RoomHolder>().SetRoomData(roomData);
            onSpawnRoom(room);
            libraryHolder.library.RoomCount++;
            spawned = true;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("RoomSpawnPoint"))
        {
            if(collision.gameObject.name != "Destroyer")
            {
                if (!collision.GetComponent<RoomSpawner>().spawned && !spawned)
                {
                    //Instantiate(library.Wall.Prefab,transform.position, Quaternion.identity);
                }
            }
            Destroy(gameObject);
        }
    }
}
