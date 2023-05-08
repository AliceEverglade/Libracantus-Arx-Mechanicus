using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public enum types
    {
        melee,
        ranged
    };
    public types type;

    public GameObject body;
    [SerializeField] private CircleCollider2D triggerCol;
    [SerializeField] private float speed = 10;
 
    private GameObject target;
    bool canAim = false;

    public GameObject bullet;
    private float shootingTime;
    [SerializeField] private float fireRate = 3f;
    [SerializeField] private float shootingPower = 20f;

    void Start()
    {
        
    }

    void Update()
    {
        if(type == types.melee)
        {
            body.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
            triggerCol.radius = 4;

            if (canAim)
            {
                float range = Vector2.Distance(transform.position, target.transform.position);
                if (range > 0)
                {
                    transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
                }

                if (range < 1)
                {
                    Debug.Log("ballsM");
                }
            }
        }

        if(type == types.ranged)
        {
            body.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1);
            triggerCol.radius = 8;

            if (canAim)
            {
                float range = Vector2.Distance(transform.position, target.transform.position);
                if (range > 4)
                {
                    transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
                }

                if (range < 5)
                {
                    Fire(target.transform);
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            target = col.gameObject;
            canAim = true;
        }
        else if (col.gameObject.CompareTag("Tower"))
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

    private void Fire(Transform target)
    {
        if (Time.time > shootingTime)
        {
            shootingTime = Time.time + fireRate / 1;
            Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
            GameObject projectile = Instantiate(bullet, myPos, Quaternion.identity);
            Vector2 direction = myPos - (Vector2)target.position;
            projectile.GetComponent<Rigidbody2D>().velocity = -direction * shootingPower;
        }
    }
}
