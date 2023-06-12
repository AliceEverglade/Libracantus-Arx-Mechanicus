using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class PotionEffect : ScriptableObject
{
    public virtual void Activate(PlayerStats stats, float potency)
    {
        
        Debug.Log("Potion effect not implemented yet.");
    }

    public virtual void Activate(PlayerStats stats, float potency, float duration)
    {

        Debug.Log("Potion effect not implemented yet.");
    }
}
