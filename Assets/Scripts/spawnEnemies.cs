using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemies : MonoBehaviour
{
    [SerializeField] private List<GameObject> spawnlist = new List<GameObject>();
    [SerializeField] private int Spawnlenght;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Spawnlenght; i++)
        {
            int spawner = Random.Range(0, spawnlist.Count);
            Instantiate(spawnlist[spawner], transform.position, transform.rotation);
        }
    }
}
