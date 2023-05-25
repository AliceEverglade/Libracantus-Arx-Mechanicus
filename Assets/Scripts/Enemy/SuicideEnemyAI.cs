using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyAI/Suicide")]
public class SuicideEnemyAI : EnemyAISO
{
    public override void Aim(EnemyScript self, EnemyStats stats, GameObject target, float attackRange)
    {
        base.Aim(self, stats, target, attackRange);
        if (Range > attackRange)
        {
            self.gameObject.transform.position = Vector2.MoveTowards(self.gameObject.transform.position, target.transform.position, self.speed * Time.deltaTime);
        }
    }
}
