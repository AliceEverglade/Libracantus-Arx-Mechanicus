using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyBullet : MonoBehaviour
{
    public float destroyTimer = 1;
    public float speed = 5;
    public float damage = 10;
    private Stats caster;

    void Start()
    {
        StartCoroutine(DestroyTimer());
    }

    private IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(destroyTimer);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //caster.CallOnHitEffects(other.GetComponent<PlayerStats>());
            other.GetComponent<PlayerStats>().CurrentHP -= damage;
            Destroy(gameObject);
        }
        if(other.gameObject.tag == "Tower")
        {
            Destroy(gameObject);
        }
    }

    public void SetCaster(Stats balls)
    {
        caster = balls;
    }
}
