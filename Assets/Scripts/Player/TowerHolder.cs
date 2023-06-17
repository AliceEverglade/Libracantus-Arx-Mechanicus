using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHolder : MonoBehaviour
{
    [SerializeField] private PlayerInventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(inventory.TowerIndex - 1 < 0)
            {
                inventory.TowerIndex = inventory.Towers.Count - 1;
            }
            else
            {
                inventory.TowerIndex--;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(inventory.TowerIndex + 1 > inventory.Towers.Count - 1)
            {
                inventory.TowerIndex = 0;
            }
            else
            {
                inventory.TowerIndex++;
            }
        }
    }
}
