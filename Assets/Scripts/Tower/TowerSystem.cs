using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TowerSystem : MonoBehaviour
{
    [SerializeField]
    private TowerStats stats;

    [SerializeField]
    private string targetTag;

    [SerializeField]
    private 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetTargets(stats, targetTag, out List<Stats> targets))
        {

        }
    }

    private bool GetTargets(TowerStats data, string tag, out List<Stats> targets)
    {
        GameObject[] objectList = GameObject.FindGameObjectsWithTag(tag);
        targets = null;
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

}
