using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    Animator RoomLoad;
    public bool AllKill = false;
    AudioSource Complete;



    // Start is called before the first frame update
    void Start()
    {
        RoomLoad = gameObject.GetComponent<Animator>();
        Complete = GetComponent<AudioSource>();
        AllKill = false;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(myWaitCoroutine());
        
        
    }

    private void objectives()
    {
        if(AllKill == false)
        {
            if (GameObject.FindObjectOfType<EnemyScript>() == null)
           {
            Debug.Log("Enemies Killed");
            RoomLoad.SetTrigger("enemies");
            AllKill = true;
            Complete.Play();
            }
        }
        
        
    }

    IEnumerator myWaitCoroutine()
    {
    yield return new WaitForSeconds(5f);
    objectives();
    // Wait for one second

    // All your Post-Delay Logic goes here:
    // Run functions
    // Set your Values
    // Or whatever else
    }
    
}
