using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureBehaviorManager : MonoBehaviour
{
    [SerializeField] private CreatureData data;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TestBehavior());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator TestBehavior()
    {
        float activity = 60;
        int r = Random.Range(1, 101);
        yield return new WaitForSeconds(3f);
        if ( r < activity)
        {
            data.ActivateBehavior();
            Debug.Log($"with {r} being lower than {activity}, behavior has been activated");
            StartCoroutine(TestBehavior());
        }
        else
        {
            StartCoroutine(TestBehavior());
        }

    }
}
