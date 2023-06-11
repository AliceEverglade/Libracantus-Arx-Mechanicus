using System.Collections;
using System.Collections.Generic;
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

    [Header("RoomList")]
    [SerializeField] private List<GameObject> roomList;
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
        if(waitTime < 0 && !doneChecking)
        {
            GameObject exit = null;
            GameObject replacedExitRoom = null;
            foreach(GameObject room in roomList)
            {
                //Debug.Log($"checking room: {room.name}");
                List<RoomData.OpeningDirections> dirs = room.GetComponent<RoomHolder>().roomData.RoomOpenings;
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

                
                //check if rooms need to be replaced by other rooms based on their surrounding rooms
                //check if there are rooms to each opening, if not then put a wall or corresponding closing room there
            }
            if(exit != null)
            {
                roomList.Remove(replacedExitRoom);
                roomList.Add(exit);
            }
            else
            {
                Debug.Log("Exit Room not found");
            }
            doneChecking = true;
        }
        else if(!doneChecking)
        {
            waitTime -= Time.deltaTime;
        }
    }


    private GameObject ReplaceRoom(GameObject original, RoomData replacer)
    {
        Vector3 pos = original.transform.position;
        Destroy(original);
        GameObject replaced = Instantiate(replacer.Prefab,pos, Quaternion.identity);
        return replaced;
    }

    private void AddRoomToList(GameObject room)
    {
        roomList.Add(room);
    }
}
