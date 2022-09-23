using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefs;

    void Start()
    {
        for(int i=0; i<10; i++)
        {
            int randEnemy = Random.Range(0, enemyPrefs.Length);
            int randSpawn = Random.Range(0, spawnPoints.Length);

            Instantiate(enemyPrefs[randEnemy], spawnPoints[randSpawn].position, transform.rotation);  
        }
    }
}
