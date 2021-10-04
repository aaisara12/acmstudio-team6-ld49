using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxManager : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] float parallaxFactor = 100;


    [Header("Background")]
    [SerializeField] GameObject background;

    [Header("Foreground")]
    [SerializeField] Transform foregroundSpawnLevel;
    [SerializeField] List<ForegroundElement> foregroundPrefabs = new List<ForegroundElement>();
    [SerializeField] float minForegroundElementSpawnInterval = 0.5f;
    [SerializeField] float maxForegroundElementSpawnInterval = 3;


    float nextSpawnTime = 0;

    void Awake()
    {
        nextSpawnTime = Time.time + maxForegroundElementSpawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        background.transform.Translate(Vector3.left * speed/parallaxFactor * Time.deltaTime);
        
        if(Time.time >= nextSpawnTime)
            SpawnForegroundElement();

    }

    void SpawnForegroundElement()
    {
        // Spawn random foreground element at given foreground level
        ForegroundElement element = Instantiate<ForegroundElement>(
            foregroundPrefabs[Random.Range(0, foregroundPrefabs.Count)], 
            foregroundSpawnLevel.position, 
            foregroundSpawnLevel.rotation
        );

        element.Initialize(-speed);

        nextSpawnTime = Time.time + Random.Range(minForegroundElementSpawnInterval, maxForegroundElementSpawnInterval);
    }
}
