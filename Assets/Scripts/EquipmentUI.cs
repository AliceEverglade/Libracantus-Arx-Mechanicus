using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentUI : MonoBehaviour
{
    [SerializeField] private PlayerInventory Inventory;
    [SerializeField] private GameObject ArmorIcon1;
    [SerializeField] private GameObject ArmorIcon2;
    [SerializeField] private GameObject ArmorIcon3;
    [SerializeField] private GameObject WeaponIcon1;
    [SerializeField] private GameObject ArtifactIcon1;
    [SerializeField] private GameObject ArtifactIcon2;
    [SerializeField] private GameObject ArtifactIcon3;

    void Start()
    {
        
    }

    
    void Update()
    {
        if(Inventory.Armors[0] != null)
        {
            ArmorIcon1.GetComponent<Image>().enabled = true;
            ArmorIcon1.GetComponent<Image>().sprite = Inventory.Armors[0].Icon;
        } else {
            ArmorIcon1.GetComponent<Image>().enabled = false;
        }

        if(Inventory.Armors[1] != null)
        {
            ArmorIcon1.GetComponent<Image>().enabled = true;
            ArmorIcon1.GetComponent<Image>().sprite = Inventory.Armors[1].Icon;
        } else {
            ArmorIcon1.GetComponent<Image>().enabled = false;
        }

        if(Inventory.Armors[2] != null)
        {
            ArmorIcon1.GetComponent<Image>().enabled = true;
            ArmorIcon1.GetComponent<Image>().sprite = Inventory.Armors[2].Icon;
        } else {
            ArmorIcon1.GetComponent<Image>().enabled = false;
        }

        if(Inventory.Sword != null)
        {
            WeaponIcon1.GetComponent<Image>().enabled = true;
            WeaponIcon1.GetComponent<Image>().sprite = Inventory.Sword.Icon;
        } else {
            WeaponIcon1.GetComponent<Image>().enabled = false;
        }

        if(Inventory.Artifacts[0] != null)
        {
            ArtifactIcon1.GetComponent<Image>().enabled = true;
            ArtifactIcon1.GetComponent<Image>().sprite = Inventory.Artifacts[0].Icon;
        } else {
            ArtifactIcon1.GetComponent<Image>().enabled = false;
        }

        if(Inventory.Artifacts[1] != null)
        {
            ArtifactIcon1.GetComponent<Image>().enabled = true;
            ArtifactIcon1.GetComponent<Image>().sprite = Inventory.Artifacts[1].Icon;
        } else {
            ArtifactIcon1.GetComponent<Image>().enabled = false;
        }

        if(Inventory.Artifacts[2] != null)
        {
            ArtifactIcon1.GetComponent<Image>().enabled = true;
            ArtifactIcon1.GetComponent<Image>().sprite = Inventory.Artifacts[2].Icon;
        } else {
            ArtifactIcon1.GetComponent<Image>().enabled = false;
        }


        
    }
}
