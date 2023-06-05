using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Data/Randomizer")]
public class RandomizerData : ScriptableObject
{
    public bool StoryMode;
    public StorySeeds StorySeeds;
    public bool RandomSeed;
    [Range(1, 9)]
    public int SeedLength;
    public int Seed;
    public void SetRandomSeed()
    {
        string seed = "";
        for (int i = 0; i < SeedLength; i++)
        {
            seed += UnityEngine.Random.Range(0, 11).ToString();
        }
        Seed = Convert.ToInt32(seed);
    }
    public void SetSeed(int seed)
    {
        UnityEngine.Random.InitState(seed);
    }

    public void StartRun()
    {
        if (!StoryMode)
        {
            if (RandomSeed)
            {
                SetRandomSeed();
            }
            SetSeed(Seed);
            Debug.Log($"Seed: {Seed}");
        }
        else
        {
            SetSeed(StorySeeds.GetSeed(StorySeeds.index));
        }
        
    }
}

[Serializable]
public class StorySeeds
{
    public int index;
    public int[] SeedList;

    public int GetSeed(int i)
    {
        return SeedList[i];
    }
}
