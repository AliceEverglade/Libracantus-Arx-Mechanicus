using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class TowerSystem : MonoBehaviour
{
    [SerializeField]
    private TowerStats stats;

    [SerializeField]
    private string targetTag;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stats.AttackSpeedCounter <= 0)
        {
            Attack();
            stats.AttackSpeedCounter = 1 / (stats.Speed * stats.SpeedMultiplier);
        }
        else
        {
            stats.AttackSpeedCounter -= Time.deltaTime;
        }

    }

    private bool GetAllTargets(TowerStats data, string tag, out List<Stats> targets)
    {
        GameObject[] objectList = GameObject.FindGameObjectsWithTag(tag);
        targets = new List<Stats>();
        foreach (GameObject obj in objectList)
        {
            if( obj.GetComponent<Stats>() != null 
                && Vector3.Distance(this.transform.position, obj.transform.position) < data.Range)
            {
                targets.Add(obj.GetComponent<Stats>());
            }
        }
        if( targets != null )
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Attack()
    {
        if (GetAllTargets(stats, targetTag, out List<Stats> targets))
        {
            List<Stats> damageTargets = stats.targetingSystem.GetTargets(stats, targets);
            foreach (Stats target in damageTargets)
            {
                stats.CallOnHitEffects(target);
            }
            Debug.Log(damageTargets.Count);
        }
    }
}
