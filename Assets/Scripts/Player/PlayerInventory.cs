using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/PlayerInventory")]
public class PlayerInventory : ScriptableObject
{
    public float Coins;
    public Player Player;
    public Artifact[] Artifacts = new Artifact[3];
    public int ArtifactIndex;
    public Armor[] Armors = new Armor[3];
    public int ArmorIndex;
    public Sword Sword;
    public List<Potion> Potions;
    public List<Tower> Towers;
    //Icons
    //Armor
    public Texture2D IconArmorLeather;
    public Texture2D IconArmorIron;
    public Texture2D IconArmorGold;

    //Artifacts
    public Texture2D IconArtifactLeaves;
    public Texture2D IconArtifactNecklace;
    public Texture2D IconArtifactPurity;
    public Texture2D IconArtifactStrength;
    public Texture2D IconArtifactSoup;

    //Potions
    public Texture2D IconPotionHealth;
    public Texture2D IconPotionSpeed;
    public Texture2D IconPotionDefence;
    public Texture2D IconPotionHaste;
    public Texture2D IconPotionStrength;

    //Swords
    public Texture2D IconSwordWooden;
    public Texture2D IconSwordIron;

    //Towers
    public Texture2D IconTowerFlame;
    public Texture2D IconTowerHealing;
    public Texture2D IconTowerIce;
    public Texture2D IconTowerPoison;
    public Texture2D IconTowerArcane;

    public void Save()
    {
        //set player current hp
        //set tower current hp and level
    }
    public GameObject Load(GameObject player)
    {
        Player.PlayerLoad(player);
        return player;
    }
    public GameObject SpawnPlayer(Vector3 pos)
    {
        return Load(Instantiate(Player.PlayerPrefab, pos, Quaternion.identity));
    }

    public void AddCoins(float amount)
    {
        Coins += amount;
    }
    public bool CanSpendCoins(float amount)
    {
        if (Coins - amount < 0)
        {
            Debug.Log("can't remove coins");
            return false;
        }
        else
        {
            Debug.Log("can remove coins");
            return true;
        }
    }

    public bool RemoveCoins(float amount)
    {
        Debug.Log("trying to remove " + amount + "coins");
        if (CanSpendCoins(amount))
        {
            Coins -= amount;
            Debug.Log("removed coins");
            return true;
        }
        else
        {
            Debug.Log("didn't remove coins");
            return false;
        }
    }

    #region Artifact Functions
    public bool AddArtifact(Artifact data)
    {
        Debug.Log("adding artifact: " + data.Name);
        if (Artifacts.Length > ArtifactIndex)
        {
            Artifacts[ArtifactIndex] = data;
            //apply stats from artifact
            ArtifactIndex++;
            return true;
        }
        else
        {
            return false;
        }
    }
    public void RemoveArtifact(int index)
    {
        if (index < Artifacts.Length)
        {
            List<Artifact> tempArtifactList = new List<Artifact>();
            int tempIndex = 0;
            //remove stats from artifact
            Artifacts[index] = null;
            foreach (Artifact item in Artifacts)
            {
                if (item != null)
                {
                    tempArtifactList.Add(item);
                }
            }
            foreach (Artifact item in tempArtifactList)
            {
                Artifacts[tempIndex] = item;
                tempIndex++;
                if (tempIndex == tempArtifactList.Count)
                {
                    ArtifactIndex = tempIndex;
                }
            }
        }
    }
    #endregion

    #region Potion Functions
    public void AddPotion(Potion data)
    {
        Potions.Add(data);
    }
    public Potion GetRandomPotion()
    {
        int index = UnityEngine.Random.Range(0, Potions.Count);
        return Potions[index];
    }

    public void ConsumePotion(PlayerStats stats)
    {
        Potion potion = GetRandomPotion();
        Potions.Remove(potion);
        potion.Effect.Activate(stats, potion.Potency, potion.Duration);
    }
    #endregion

    #region Armor and Sword Functions
    public bool AddArmor(Armor data)
    {
        if (Armors.Length > ArmorIndex)
        {
            Armors[ArmorIndex] = data;
            //apply stats from armor
            ArmorIndex++;
            return true;
        }
        else
        {
            return false;
        }
    }
    public void RemoveArmor(int index)
    {
        if (index < Armors.Length)
        {
            List<Armor> tempArmorList = new List<Armor>();
            int tempIndex = 0;
            //remove stats from armor
            Artifacts[index] = null;
            foreach (Armor item in Armors)
            {
                if (item != null)
                {
                    tempArmorList.Add(item);
                }
            }
            foreach (Armor item in tempArmorList)
            {
                Armors[tempIndex] = item;
                tempIndex++;
                if (tempIndex == tempArmorList.Count)
                {
                    ArmorIndex = tempIndex;
                }
            }
        }
    }

    public void SetSword(Sword data, PlayerStats stats)
    {
        stats.StrengthMultiplier -= Sword.damageModifier;
        Sword = data;
        stats.StrengthMultiplier += Sword.damageModifier;
    }
    #endregion

    #region Tower Functions
    public void AddTower(Tower data)
    {
        Towers.Add(data);
    }
    public void RemoveTower(Tower data)
    {
        Towers.Remove(data);
    }
    public void SpawnTower(Tower data)
    {
        //spawn tower
    }
    public void DespawnTower(Tower data)
    {
        //despawn tower
    }
    #endregion
}

[Serializable]
public class Player
{
    public GameObject PlayerPrefab;
    public float CurrentHP;
    public void PlayerLoad(GameObject player)
    {
        player.GetComponent<PlayerStats>().CurrentHP = CurrentHP;
    }
}

[Serializable]
public class Artifact
{
    public Sprite Icon;
    public string Name;
    public PlayerStatBuff BuffType;
    public float Potency;
}

[Serializable]
public class Potion
{
    public Sprite Icon;
    public string Name;
    public PotionEffect Effect;
    public float Potency;
    public float Duration;

    public void Activate(PlayerStats stats)
    {
        Effect.Activate(stats, Potency, Duration);
    }
}

[Serializable]
public class Tower
{
    public Sprite Icon;
    public string Name;
    public bool IsSpawned;
    public GameObject BaseTower;
    public float CurrentHP;
    public int TowerLevel;
    public GameObject TowerReference;
}

[Serializable]
public class Armor
{
    public Sprite Icon;
    public string Name;
    public float HPValue;
}

[Serializable]
public class Sword
{
    public Sprite Icon;
    public string Name;
    public float damageModifier;
}