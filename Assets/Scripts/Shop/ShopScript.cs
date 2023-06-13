using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{
    // Canvas's to turn them on & off (enter/exit)
    public Canvas PotionsShop;
    public Canvas BlackSmithShop;
    public Canvas ArtifactShop;
    public Canvas TowerShop;

    // Have nothing assigned (maybe need later to see if its on or off)
    private bool IsShowingPot;
    private bool IsShowingBS;
    private bool IsShowingArt;
    private bool IsShowingTow;

    //item Lists
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private PlayerStats playerStats;
    public List<PotionShopItem> PotionShopItems;
    public List<ArtifactShopItem> ArtifactShopItems;
    public List<TowerShopItem> TowerShopItems;
    public List<SwordShopItem> SwordShopItems;
    public List<ArmorShopItem> ArmorShopItems;

    private void OnEnable()
    {
        PlayerStats.onReferenceSet += SetPlayerRef;
    }

    private void OnDisable()
    {
        PlayerStats.onReferenceSet += SetPlayerRef;
    }

    private void SetPlayerRef(GameObject player)
    {
        playerStats = player.GetComponent<PlayerStats>();
    }

    private void OnValidate()
    {
        foreach(PotionShopItem item in PotionShopItems)
        {
            item.Name = item.Potion.Name;
        }
        foreach(ArtifactShopItem item in ArtifactShopItems)
        {
            item.Name = item.Artifact.Name;
        }
        foreach(ArmorShopItem item in ArmorShopItems)
        {
            item.Name = item.Armor.Name;
        }
        foreach(SwordShopItem item in SwordShopItems)
        {
            item.Name = item.Sword.Name;
        }
        foreach(TowerShopItem item in TowerShopItems)
        {
            item.Name = item.Tower.Name;
        }
    }

    #region buying functions
    public void BuyPotion(int index)
    {
        if (playerInventory.RemoveCoins(PotionShopItems[index].Price))
        {
            playerInventory.AddPotion(PotionShopItems[index].Potion);
        }
    }

    public void BuyArtifact(int index)
    {
        if (playerInventory.RemoveCoins(ArtifactShopItems[index].Price))
        {
            if (!playerInventory.AddArtifact(ArtifactShopItems[index].Artifact))
            {
                playerInventory.AddCoins(ArtifactShopItems[index].Price);
            }
        }
    }

    public void BuyArmor(int index)
    {
        if (playerInventory.RemoveCoins(ArmorShopItems[index].Price))
        {
            if (!playerInventory.AddArmor(ArmorShopItems[index].Armor))
            {
                playerInventory.AddCoins(ArmorShopItems[index].Price);
            }
        }
    }

    public void BuySword(int index)
    {
        if (playerInventory.RemoveCoins(SwordShopItems[index].Price))
        {
            playerInventory.SetSword(SwordShopItems[index].Sword, playerStats);
        }
    }

    public void BuyTower(int index)
    {
        if (playerInventory.RemoveCoins(SwordShopItems[index].Price))
        {
            playerInventory.AddTower(TowerShopItems[index].Tower);
        }
    }
    #endregion
}

[Serializable]
public class PotionShopItem
{
    [HideInInspector]
    public string Name;
    public Potion Potion;
    public float Price;
}

[Serializable]
public class ArmorShopItem
{
    [HideInInspector]
    public string Name;
    public Armor Armor;
    public float Price;
}

[Serializable]
public class SwordShopItem
{
    [HideInInspector]
    public string Name;
    public Sword Sword;
    public float Price;
}

[Serializable]
public class ArtifactShopItem
{
    [HideInInspector]
    public string Name;
    public Artifact Artifact; 
    public float Price;
}

[Serializable]
public class TowerShopItem
{
    [HideInInspector]
    public string Name;
    public Tower Tower; 
    public float Price;
}
