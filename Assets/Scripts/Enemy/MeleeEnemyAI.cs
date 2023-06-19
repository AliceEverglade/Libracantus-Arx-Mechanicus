using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyAI/Melee")]
public class MeleeEnemyAI : EnemyAISO
{
    public override void Aim(EnemyScript self, EnemyStats stats, GameObject target, float attackRange)
    {
        base.Aim(self, stats, target, attackRange);
        if (Range > attackRange)
        {
            self.gameObject.transform.position = Vector2.MoveTowards(self.gameObject.transform.position, target.transform.position, self.speed * Time.deltaTime);
            if(self.gameObject.transform.position.x > target.transform.position.x)
            {
                self.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                self.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        if (Range < attackRange)
        {
            //stats.CallOnHitEffects(target.GetComponent<Stats>());
            target.GetComponent<PlayerStats>().CurrentHP -= 10;
            if (self.gameObject.transform.position.x > target.transform.position.x)
            {
                self.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                self.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
    }
}
