using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAISO : ScriptableObject
{
    protected float Range;
    public virtual void Aim(EnemyScript self, EnemyStats stats, GameObject target, float attackRange)
    {
        Range = Vector2.Distance(self.gameObject.transform.position, target.transform.position);
    }
    public virtual void Aim(EnemyScript self, EnemyStats stats, GameObject target, float closeRange, float attackRange, float farRange)
    {
        Range = Vector2.Distance(self.gameObject.transform.position, target.transform.position);
    }

    public void Fire(EnemyStats stats, GameObject weaponMuzzle, Vector2 target, GameObject bullet)
    {
        if (Time.time > stats.shootingTime)
        {
            stats.shootingTime = Time.time + stats.fireRate / 1000;
            Vector2 myPos = new Vector2(weaponMuzzle.transform.position.x, weaponMuzzle.transform.position.y);
            GameObject projectile = Instantiate(bullet, myPos, Quaternion.identity);
            projectile.GetComponent<EnemyBullet>().SetCaster(stats);
            Vector2 direction = myPos - target;
            projectile.GetComponent<Rigidbody2D>().velocity = -direction * stats.shootingPower;
        }
    }
}
