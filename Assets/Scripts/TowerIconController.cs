using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerIconController : MonoBehaviour
{
    [SerializeField] private PlayerInventory inventory;
    [SerializeField] private Image image;

    [SerializeField] private Color grayedOutColor;
    [SerializeField] private Color transparentColor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(inventory.Towers.Count != 0)
        {
            image.sprite = inventory.Towers[inventory.TowerIndex].Icon;
            image.color = inventory.Towers[inventory.TowerIndex].IsSpawned ? grayedOutColor : Color.white;
        }
        else
        {
            image.color = transparentColor; 
            image.sprite = null;
        }
    }
}
