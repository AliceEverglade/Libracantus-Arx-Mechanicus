using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public abstract class EnemyAISO : ScriptableObject
{
    public EnemyStats stats;
    public float Range;
    public virtual void Aim(EnemyScript self, GameObject target, float attackRange)
    {
        Range = Vector2.Distance(self.gameObject.transform.position, target.transform.position);
    }
    public virtual void Aim(EnemyScript self, GameObject target, float closeRange, float attackRange, float farRange)
    {
        Range = Vector2.Distance(self.gameObject.transform.position, target.transform.position);
    }

    public void Fire(GameObject weaponMuzzle, Vector2 target, GameObject bullet)
    {
        if (Time.time > stats.shootingTime)
        {
            stats.shootingTime = Time.time + stats.fireRate / 1000;
            Vector2 myPos = new Vector2(weaponMuzzle.transform.position.x, weaponMuzzle.transform.position.y);
            GameObject projectile = Instantiate(bullet, myPos, Quaternion.identity);
            Vector2 direction = myPos - (Vector2)target;
            projectile.GetComponent<Rigidbody2D>().velocity = -direction * stats.shootingPower;
        }
    }
}
