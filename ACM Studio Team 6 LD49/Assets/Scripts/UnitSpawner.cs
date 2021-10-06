using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> unitsToSpawn = new List<GameObject>();
    [SerializeField] float spawnTimer = 3;
    float timeOfLastSpawn = 0;

    void Awake()
    {
        timeOfLastSpawn = spawnTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - timeOfLastSpawn > spawnTimer)
        {
            Instantiate(unitsToSpawn[Random.Range(0, unitsToSpawn.Count)], transform.position, transform.rotation);
            timeOfLastSpawn = Time.time;
        }
    }
}
