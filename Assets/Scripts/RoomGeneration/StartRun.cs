using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartRun : MonoBehaviour
{
    [Header("Randomizing")]
    [SerializeField] private RandomizerData data;

    [Header("RoomGeneration")]
    public RoomLibrary library;
    public int RoomsSpawned;
    public int RoomCap;
    [SerializeField] private float waitTime = 4;
    [SerializeField] private bool exitRoomSpawned;
    [SerializeField] private bool doneChecking = false;
    private float roomSize = 16;

    [Header("RoomList")]
    [SerializeField] private List<GameObject> roomList;

    [Header("References")]
    [SerializeField] private CameraFollow cam;
    // Start is called before the first frame update
    private void Awake()
    {
        data.StartRun();
    }

    private void Start()
    {
        library.RoomCount = 0;
        library.StartGeneration(this.gameObject);
        
    }

    private void Setup()
    {
        PlayerSetup player = this.gameObject.GetComponent<PlayerSetup>();
        player.Setup();
    }

    private void OnEnable()
    {
        RoomSpawner.onSpawnRoom += AddRoomToList;
    }

    private void OnDisable()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RoomsSpawned = library.RoomCount;
        if (waitTime < 0 && !doneChecking)
        {
            GameObject exit = null;
            GameObject replacedRoom = null;
            GameObject newRoom = null;
            foreach (GameObject room in roomList)
            {
                List<RoomData.OpeningDirections> dirs = room.GetComponent<RoomHolder>().roomData.RoomOpenings;
                List<RoomData.OpeningDirections> replacementDirs = new List<RoomData.OpeningDirections>();
                foreach (RoomData.OpeningDirections dir in dirs)
                {
                    if (CheckSurroundings(dir, room.transform.position, out RoomData.OpeningDirections newRoomDir))
                    {
                        replacementDirs.Add(newRoomDir);
                    }
                }
                /*
                if(replacementDirs != null)
                {
                    Debug.Log($"replacing room {}");
                    RoomData newRoomData = library.GetRoom(replacementDirs);
                    newRoom = ReplaceRoom(room, newRoomData);
                }*/
                if (!exitRoomSpawned && dirs != null)
                {
                    int counter = 0;

                    foreach (RoomData.OpeningDirections dir in dirs)
                    {
                        if (library.Exit.RoomOpenings.Contains(dir))
                        {
                            counter++;
                        }
                    }
                    if (counter == room.GetComponent<RoomHolder>().roomData.RoomOpenings.Count)
                    {
                        Debug.Log($"{room.name} is replaced with the exit");
                        exit = ReplaceRoom(room, library.Exit);

                        exitRoomSpawned = true;
                    }
                }
            }
            if (exit != null)
            {
                roomList.Remove(replacedRoom);
                roomList.Add(exit);
                foreach (RoomData.OpeningDirections dir in library.Exit.RoomOpenings)
                {
                    CheckSurroundings(dir, exit.transform.position, out RoomData.OpeningDirections exitRoomDir);
                }
            }
            else
            {
                Debug.Log("Exit Room not found");
            }
            if (newRoom != null)
            {
                roomList.Remove(replacedRoom);
                roomList.Add(newRoom);
            }
            doneChecking = true;
            Setup();
        }
        else if (!doneChecking)
        {
            waitTime -= Time.deltaTime;
        }
    }


    private GameObject ReplaceRoom(GameObject original, RoomData replacer)
    {
        Vector3 pos = original.transform.position;
        Destroy(original);
        GameObject replaced = Instantiate(replacer.Prefab, pos, Quaternion.identity);
        return replaced;
    }

    private void AddRoomToList(GameObject room)
    {
        roomList.Add(room);
    }

    private bool CheckSurroundings(RoomData.OpeningDirections direction, Vector3 origin, out RoomData.OpeningDirections newRoomDir)
    {
        Vector3 dir = new Vector3(0, 0, 0);
        RoomData.OpeningDirections otherRoomDir;
        switch (direction)
        {
            case RoomData.OpeningDirections.North:
                dir = new Vector3(0, roomSize, 0);
                otherRoomDir = RoomData.OpeningDirections.South;
                break;
            case RoomData.OpeningDirections.East:
                dir = new Vector3(roomSize, 0, 0);
                otherRoomDir = RoomData.OpeningDirections.West;
                break;
            case RoomData.OpeningDirections.South:
                dir = new Vector3(0, -roomSize, 0);
                otherRoomDir = RoomData.OpeningDirections.North;
                break;
            case RoomData.OpeningDirections.West:
                dir = new Vector3(-roomSize, 0, 0);
                otherRoomDir = RoomData.OpeningDirections.East;
                break;
            default:
                newRoomDir = RoomData.OpeningDirections.North;
                return false;
        }
        List<GameObject> targets = new List<GameObject>();
        Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(dir.x + origin.x, dir.y + origin.y), 1);
        foreach (Collider2D col in colliders)
        {
            if (col.CompareTag("Room"))
            {
                targets.Add(col.gameObject);
            }
        }
        if (targets.Count > 0)
        {
            foreach (GameObject target in targets)
            {
                if (target.GetComponent<RoomHolder>().roomData.RoomOpenings.Contains(otherRoomDir))
                {
                    newRoomDir = direction;
                    return true;
                }
            }
        }
        else
        {
            Instantiate(library.Wall.Prefab, new Vector3(origin.x + dir.x, origin.y + dir.y, 0), Quaternion.identity);
            newRoomDir = RoomData.OpeningDirections.North;
        }
        newRoomDir = RoomData.OpeningDirections.North;
        return false;
    }
}
