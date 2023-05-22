using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float destroyTimer = 1;

    void Start()
    {
        StartCoroutine(DestroyTimer());
    }

    private IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(destroyTimer);
        Destroy(gameObject);
    }
}
