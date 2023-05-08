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

    public SpriteRenderer body;
    [SerializeField] private CircleCollider2D triggerCol;

    private GameObject target;
    Vector3 lookPos;
    [SerializeField] private int smoothTurn = 2;

    void Start()
    {
        
    }

    void Update()
    {
        if(type == types.melee)
        {
            body.color = new Color(1, 0, 0);
            triggerCol.radius = 4;
            Aim();
        }

        if(type == types.ranged)
        {
            body.color = new Color(0, 0, 1);
            triggerCol.radius = 8;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Tower"))
        {
            target = col.gameObject;
        }
    }

    private void Aim()
    {
        lookPos = target.transform.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * smoothTurn);
    }
}
