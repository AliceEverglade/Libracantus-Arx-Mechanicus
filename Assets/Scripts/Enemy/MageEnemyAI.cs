using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyAI/Mage")]
public class MageEnemyAI : EnemyAISO
{
    public override void Aim(EnemyScript self, EnemyStats stats, GameObject target, float closeRange, float attackRange, float farRange)
    {
        base.Aim(self, stats, target, attackRange);
        if (Range >= farRange)
        {
            self.gameObject.transform.position = Vector2.MoveTowards(self.gameObject.transform.position, target.transform.position, self.speed * Time.deltaTime);
        }
        if (Range <= closeRange)
        {
            self.gameObject.transform.position = Vector2.MoveTowards(self.gameObject.transform.position, self.gameObject.transform.position - target.transform.position, self.speed * Time.deltaTime);
        }
        if (Range <= attackRange)
        {
            Fire(stats, self.body, target.transform.position, self.bullet);
        }
    }
}
