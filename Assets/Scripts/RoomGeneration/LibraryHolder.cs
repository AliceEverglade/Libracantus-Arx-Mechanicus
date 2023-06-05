using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryHolder : MonoBehaviour
{
    public RoomLibrary library;
    public int RoomsSpawned;
    public int RoomCap;

    private void Start()
    {
        library.RoomCount = 0;
    }
    private void Update()
    {
        RoomsSpawned = library.RoomCount;
    }
}
