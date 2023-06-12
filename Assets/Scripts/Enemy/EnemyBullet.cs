using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float destroyTimer = 1;
    public float speed = 5;
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
            caster.CallOnHitEffects(other.GetComponent<PlayerStats>());
            Destroy(gameObject);
        }
    }

    public void SetCaster(Stats balls)
    {
        caster = balls;
    }
}
