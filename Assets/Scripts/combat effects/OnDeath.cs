using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="death function")]
public class OnDeath : ScriptableObject
{
    public static event Action<Stats,GameObject> OnCreatureDeath;
    public void Die(Stats stats, GameObject self)
    {
        OnCreatureDeath(stats,self);
        Destroy(self);
    }
}
