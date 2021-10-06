using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    [SerializeField]
    private float xLimit;
    [SerializeField]
    private float[] xPositions;
    [SerializeField]
    private GameObject[] enemyPrefabs;
    [SerializeField]
    private Wave[] wave;
    [SerializeField] float spawnHeight;

    private float currentTime;

    List<float> remainingPositions = new List<float>();
    private int waveIndex;
    float xPos = 0;
    int rand;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
        remainingPositions.AddRange(xPositions);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            selectWave();
        }
    }

    void SpawnEnemy(float xPos)
    {
        GameObject enemyObj = Instantiate(enemyPrefabs[0], new Vector3(xPos, spawnHeight, 0), Quaternion.identity);
    }

    void selectWave()
    {
        remainingPositions = new List<float>();
        remainingPositions.AddRange(xPositions);
        
        waveIndex = Random.Range(0, wave.Length);

        currentTime = wave[waveIndex].delayTime;

        if (wave[waveIndex].spawnAmount == 1)
            xPos = Random.Range(-xLimit, 0);
        else if (wave[waveIndex].spawnAmount > 1)
        {
            rand = Random.Range(0, remainingPositions.Count);
            xPos = remainingPositions[rand];
            remainingPositions.RemoveAt(rand);
        }

        for (int k = 0; k < wave[waveIndex].spawnAmount; k++)
        {
            SpawnEnemy(xPos);
            rand = Random.Range(0, remainingPositions.Count);
            xPos = remainingPositions[rand];
            remainingPositions.RemoveAt(rand);
        }
    }
}

[System.Serializable]
public class Wave
{
    public float delayTime;
    public float spawnAmount;
}
