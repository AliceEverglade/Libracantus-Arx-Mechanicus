using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    [SerializeField] private RoomData.OpeningDirections spawnDirection;
    private RoomLibrary library;
    private LibraryHolder libraryHolder;
    private RoomData roomData;
    private bool spawned = false;

    private void Start()
    {
        libraryHolder = GameObject.Find("RoomLibraryHolder").GetComponent<LibraryHolder>();
        library = libraryHolder.library;
        Invoke("Spawn", 0.1f);
    }
    private void Spawn()
    {
        if (!spawned && libraryHolder.library.RoomCount < libraryHolder.RoomCap)
        {
            switch (spawnDirection)
            {
                case RoomData.OpeningDirections.North:
                    roomData = library.GetRoom(RoomData.OpeningDirections.South);
                    break;
                case RoomData.OpeningDirections.East:
                    roomData = library.GetRoom(RoomData.OpeningDirections.West);
                    break;
                case RoomData.OpeningDirections.South:
                    roomData = library.GetRoom(RoomData.OpeningDirections.North);
                    break;
                case RoomData.OpeningDirections.West:
                    roomData = library.GetRoom(RoomData.OpeningDirections.East);
                    break;
            }
            Instantiate(roomData.Prefab, transform.position, Quaternion.identity);
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
