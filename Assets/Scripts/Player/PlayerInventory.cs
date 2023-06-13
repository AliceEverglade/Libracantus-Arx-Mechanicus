using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/PlayerInventory")]
public class PlayerInventory : ScriptableObject
{
    public float Coins;
    public Player Player;
    [SerializeField] private PlayerStats stats;
    public Artifact[] Artifacts = new Artifact[3];
    public int ArtifactIndex;
    public Armor[] Armors = new Armor[3];
    public int ArmorIndex;
    public Sword Sword;
    public List<Potion> Potions;
    public List<Tower> Towers;

    public void Save()
    {
        //set tower current hp and level
    }
    public void Load(GameObject player)
    {
        Player.PlayerLoad(player);
    }
    public void SpawnPlayer(Vector3 pos)
    {
        Load(Instantiate(Player.PlayerPrefab, pos, Quaternion.identity));
    }

    public void Setup()
    {
        Player.PlayerReference = Instantiate(Player.PlayerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        stats = Player.PlayerReference.GetComponent<PlayerStats>();
    }

    public void AddCoins(float amount)
    {
        Coins += amount;
    }
    public bool CanSpendCoins(float amount)
    {
        if (Coins - amount < 0) return false;
        else return true;
    }

    public bool RemoveCoins(float amount)
    {
        if (CanSpendCoins(amount))
        {
            Coins -= amount;
            return true;
        }
        else return false;
    }

    #region Artifact Functions
    public bool AddArtifact(Artifact data)
    {
        if (Artifacts.Length < ArtifactIndex)
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

    public void ConsumePotion()
    {
        Potion potion = GetRandomPotion();
        Potions.Remove(potion);
        potion.Effect.Activate(stats, potion.Potency, potion.Duration);
    }
    #endregion

    #region Armor and Sword Functions
    public bool AddArmor(Armor data)
    {
        if (Armors.Length < ArmorIndex)
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

    public void SetSword(Sword data)
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
    public GameObject PlayerReference;
    public float CurrentHP;
    public void PlayerLoad(GameObject player)
    {
        PlayerReference = player;
        player.GetComponent<PlayerStats>().CurrentHP = CurrentHP;
    }
}

[Serializable]
public class Artifact
{
    public string Name;
    public PlayerStatBuff BuffType;
    public float Potency;
}

[Serializable]
public class Potion
{
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
    public string Name;
    public GameObject BaseTower;
    public float CurrentHP;
    public int TowerLevel;
    public GameObject TowerReference;
}

[Serializable]
public class Armor
{
    public string Name;
    public float HPValue;
}

[Serializable]
public class Sword
{
    public string Name;
    public float damageModifier;
}