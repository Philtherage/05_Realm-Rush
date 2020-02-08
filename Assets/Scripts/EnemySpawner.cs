using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Enemy enemyToSpawn;
    [SerializeField] float timeBetweenSpawns = 3f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenSpawns);
            Enemy spawnedEnemey = Instantiate(enemyToSpawn, transform.position, Quaternion.identity) as Enemy;
            spawnedEnemey.transform.parent = gameObject.transform;
            
        }
    }

}
