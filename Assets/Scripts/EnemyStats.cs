using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : Stats
{
    public float shootingTime;
    public float fireRate = 3f;
    public float shootingPower = 20f;

    public float speed;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void BasicAttack()
    {
        //check collision or so idk
        DmgRef.TakeDamage(this /*<- this is wrong */, this, 20);
    }
}
