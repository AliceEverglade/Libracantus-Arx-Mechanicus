using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    [SerializeField] private PlayerInventory inventory;
    [SerializeField] private Vector3 spawnPlayerPos;
    [SerializeField] GameObject PlayerReference;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setup()
    {
        PlayerReference = inventory.SpawnPlayer(spawnPlayerPos);
        PlayerReference.GetComponent<PlayerStats>();
    }
}
