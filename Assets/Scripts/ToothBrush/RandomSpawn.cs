using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public List<Transform> spawnPoints;
    public List<GameObject> enemyPrefs;
    [SerializeField] private int MaxKotoran;
    [SerializeField] private int MinKotoran;

    void Start()
    {
        int JmlKotoran = Random.Range(MinKotoran, MaxKotoran);
        for(int i=0; i<=JmlKotoran; i++)
        {
            int randEnemy = Random.Range(0, enemyPrefs.Count);
            int randSpawn = Random.Range(0, spawnPoints.Count);

            GameObject kotoran = Instantiate(enemyPrefs[randEnemy], spawnPoints[randSpawn].position, transform.rotation);
            spawnPoints.RemoveAt(randSpawn);
        }
    }
}
