using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Round> rounds;
    [SerializeField] private float timeBetweenRounds;
    [SerializeField] private float maxX;
    [SerializeField] private float minX;
    [SerializeField] private float maxY;
    [SerializeField] private float minY;

    void Start()
    {
        StartCoroutine(SpawnEnemies(timeBetweenRounds));
    }

    IEnumerator SpawnEnemies(float timer)
    {
        foreach (var round in rounds)
        {
            foreach (var enemy in round.enemyPrefabs)
            {
                float rndX = Random.Range(minX, maxX);
                float rndY = Random.Range(minY, maxY);
                Instantiate(enemy, new Vector2(rndX, rndY), Quaternion.identity);
                yield return new WaitForSeconds(round.spawnRate);
            }
            yield return new WaitForSeconds(timer);
        }
    }
}

[System.Serializable]
public class Round
{
    public float spawnRate;
    public GameObject[] enemyPrefabs;
}
