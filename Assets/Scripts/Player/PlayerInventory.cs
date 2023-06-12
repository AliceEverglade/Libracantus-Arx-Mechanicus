using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/PlayerInventory")]
public class PlayerInventory : ScriptableObject
{
    public float Coins;
    public GameObject PlayerReference;
    public Artifact[] Artifacts = new Artifact[3];
    public int ArtifactIndex;
    public Armor[] Armors = new Armor[3];
    public int ArmorIndex;
    public Sword Sword;
    public List<Potion> Potions;
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

}

[Serializable]
public class Tower
{

    public GameObject TowerReference;
}

[Serializable]
public class Armor
{

}

[Serializable]
public class Sword
{

}