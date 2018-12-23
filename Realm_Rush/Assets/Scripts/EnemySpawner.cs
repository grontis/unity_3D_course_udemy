using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float secondsBetweenSpawns = 3f;
    [SerializeField] private EnemyMovement enemyPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RepeatedlySpawnEnemies());
    }

    //coroutine
    IEnumerator RepeatedlySpawnEnemies()
    {
        //forever loop
        while (true)
        {
            print("Spawning");
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
        //forever
            //spawn enemy
            //wait a bit
}
