using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] spawnPoint;
    public GameObject zombie;
    public float minSpawnTime = 3f, maxSpawnTime = 5f;
    private float lastSpawnTime = 0;
    private float spawnTime;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = GameObject.FindGameObjectsWithTag("SpawnPoint");
        UpdateSpawnTime();
    }
    void UpdateSpawnTime()
    {
        lastSpawnTime = Time.time;
        spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }
    void Spawn()
    {
        int point = Random.Range(0, spawnPoint.Length);
        Instantiate(zombie,spawnPoint[point].transform.position,Quaternion.identity);
        UpdateSpawnTime();
    }
    // Update is called once per frame
    void Update()
    {
        if(Time.time>=lastSpawnTime+spawnTime)
        {
            Spawn();
        }
    }
}
