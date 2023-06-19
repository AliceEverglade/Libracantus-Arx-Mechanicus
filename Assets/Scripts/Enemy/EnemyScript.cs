using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public enum types
    {
        melee,
        ranged,
        mage,
        suicide
    };
    [Header("Enemy type")]
    [SerializeField] private types type;
    public EnemyAISO AI;
    [SerializeField] private EnemyStats stats;

    [Header("General")]
    public GameObject body;
    [SerializeField] private CircleCollider2D triggerCol;
    public float speed = 10;

    private GameObject target;
    bool canAim = false;

    [Header("Ranged enemy bullets")]
    public GameObject bullet;


    private void Start()
    {
        stats = this.GetComponent<EnemyStats>();
    }

    void Update()
    {
        if(type == types.melee)
        {
            triggerCol.radius = 4;
            if (canAim)
            {
                AI.Aim(this,stats, target, 0.5f);
            }
        }

        if(type == types.ranged)
        {
            triggerCol.radius = 8;
            if (canAim)
            {
                AI.Aim(this,stats, target, 3.5f, 5, 4);
            }
        }

        if (type == types.mage)
        {
            triggerCol.radius = 7;
            if (canAim)
            {
                AI.Aim(this,stats, target, 3.5f, 5, 4);
            }
        }

        if(type == types.suicide)
        {
            triggerCol.radius = 9;
            if (canAim)
            {
                AI.Aim(this,stats, target, 0.5f);
            }
        }

        if(!canAim)
        {
            float rndX = Random.Range(transform.position.x - 11, transform.position.x + 10);
            float rndY = Random.Range(transform.position.y - 11, transform.position.y + 10);
            Idle(new Vector3(rndX, rndY));
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") && !canAim)
        {
            target = col.gameObject;
            canAim = true;
        }
        else if (col.gameObject.CompareTag("Tower") && !canAim)
        {
            target = col.gameObject;
            canAim = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (target)
        {
            canAim = false;
        }
    }

    public void Idle(Vector3 pos)
    {
        float range = Vector2.Distance(transform.position, pos);
        if (range > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, pos, speed * Time.deltaTime);
        }
    }
}
