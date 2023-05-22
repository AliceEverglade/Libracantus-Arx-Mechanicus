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

    [Header("General")]
    public GameObject body;
    [SerializeField] private CircleCollider2D triggerCol;
    public float speed = 10;

    private GameObject target;
    bool canAim = false;

    [Header("Ranged enemy bullets")]
    private GameObject weaponMuzzle;
    public GameObject bullet;
    public float shootingTime;
    public float fireRate = 3f;
    public float shootingPower = 20f;

    void Start()
    {
        weaponMuzzle = body;
    }

    void Update()
    {
        if(type == types.melee)
        {
            body.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
            triggerCol.radius = 4;
            if (canAim)
            {
                AI.Aim(this, target, 0);
            }
        }

        if(type == types.ranged)
        {
            body.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1);
            triggerCol.radius = 8;
            if (canAim)
            {
                AI.Aim(this, target, 3.5f, 5, 4);
            }
        }

        if (type == types.mage)
        {
            body.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0);
            triggerCol.radius = 7;
            if (canAim)
            {
                AI.Aim(this, target, 3.5f, 5, 4);
            }
        }

        if(type == types.suicide)
        {
            body.GetComponent<SpriteRenderer>().color = new Color(0, 1, 1);
            triggerCol.radius = 9;
            if (canAim)
            {
                AI.Aim(this, target, 0);
            }
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
