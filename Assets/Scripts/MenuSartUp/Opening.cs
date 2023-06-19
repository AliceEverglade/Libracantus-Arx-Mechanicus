using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opening : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerInventory Inventory;
    void Start()
    {
        Inventory.ResetInventory();
        Inventory.AddCoins(35);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
