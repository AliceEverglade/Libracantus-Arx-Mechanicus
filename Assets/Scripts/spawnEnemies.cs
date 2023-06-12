using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemies : MonoBehaviour
{
    [SerializeField] private List<GameObject> spawnlist = new List<GameObject>();
    [SerializeField] private int Spawnlenght;
    [SerializeField] private float wait;
    public GameObject spawner;
    public bool restart;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitSpawn(wait));
    }

    // Update is called once per frame
    void Update()
    {
        if (restart)
        {
            StartCoroutine(WaitSpawn(wait));
        }
    }
    private IEnumerator WaitSpawn(float wait)
    {
        restart = false;

        yield return new WaitForSeconds(wait);

        for (int i = 0; i < Spawnlenght; i++)
        {
            int spawns = Random.Range(0, spawnlist.Count);
            Instantiate(spawnlist[spawns], spawner.transform.position, transform.rotation);
        }

        restart = true;
    }
}
