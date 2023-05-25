using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyAI/Melee")]
public class MeleeEnemyAI : EnemyAISO
{
    public override void Aim(EnemyScript self, GameObject target, float attackRange)
    {
        base.Aim(self, target, attackRange);
        if (Range > attackRange)
        {
            self.gameObject.transform.position = Vector2.MoveTowards(self.gameObject.transform.position, target.transform.position, self.speed * Time.deltaTime);
        }
    }
}