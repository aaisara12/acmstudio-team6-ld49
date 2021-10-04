using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxManager : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] float parallaxFactor = 100;


    [Header("Background")]
    [SerializeField] GameObject firstBackground;
    [SerializeField] GameObject secondBackground;
    [SerializeField] Transform endTransform;
    Vector3 startPosition;
    GameObject mainBackground;
    GameObject nextBackground;
    float distanceBetweenBackgrounds;

    [Header("Foreground")]
    [SerializeField] Transform foregroundSpawnLevel;
    [SerializeField] List<ForegroundElement> foregroundPrefabs = new List<ForegroundElement>();
    [SerializeField] float minForegroundElementSpawnInterval = 0.5f;
    [SerializeField] float maxForegroundElementSpawnInterval = 3;


    float nextSpawnTime = 0;

    void Awake()
    {
        nextSpawnTime = Time.time + maxForegroundElementSpawnInterval;
        mainBackground = firstBackground;
        nextBackground = secondBackground;

        // Assumes that where the second background starts is where new backgrounds should be respawned
        startPosition = secondBackground.transform.position;

        distanceBetweenBackgrounds = secondBackground.transform.position.x - firstBackground.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        firstBackground.transform.Translate(Vector3.left * speed/parallaxFactor * Time.deltaTime);
        secondBackground.transform.Translate(Vector3.left * speed/parallaxFactor * Time.deltaTime);
        
        if(Time.time >= nextSpawnTime)
            SpawnForegroundElement();

        if(mainBackground.transform.position.x <= endTransform.position.x)
        {
            mainBackground.transform.position = nextBackground.transform.position + (Vector3.right * distanceBetweenBackgrounds);

            GameObject temp = mainBackground;
            mainBackground = nextBackground;
            nextBackground = temp;
        }

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
