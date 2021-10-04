using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnFlyingEnemyOnly : MonoBehaviour
{
    [SerializeField]
    private float[] xPositions;
    [SerializeField]
    private float[] yPositions;
    [SerializeField]
    private GameObject[] enemyPrefabs;
    [SerializeField]
    private Wave[] wave;

    private float currentTime;

    List<float> remainingPositions = new List<float>();
    List<float> remainingPositionsY = new List<float>();

    private int waveIndex;
    float xPos = 0;
    float yPos = 0;
    int rand;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
        remainingPositions.AddRange(xPositions);
        remainingPositionsY.AddRange(yPositions);
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

    void SpawnEnemy(float xPos, float yPos)
    {
        GameObject enemyObj = Instantiate(enemyPrefabs[0], new Vector3(xPos, yPos, 0), Quaternion.identity);
    }

    void selectWave()
    {
        remainingPositions = new List<float>();
        remainingPositionsY = new List<float>();
        remainingPositions.AddRange(xPositions);
        remainingPositionsY.AddRange(yPositions);

        waveIndex = Random.Range(0, wave.Length);

        currentTime = wave[waveIndex].delayTime;

        if (wave[waveIndex].spawnAmount == 1)
        {
            rand = Random.Range(0, remainingPositions.Count);
            xPos = remainingPositions[rand];
            yPos = remainingPositionsY[rand];
            remainingPositions.RemoveAt(rand);
            remainingPositionsY.RemoveAt(rand);
        }
        else if (wave[waveIndex].spawnAmount > 1)
        {
            rand = Random.Range(0, remainingPositions.Count);
            xPos = remainingPositions[rand];
            yPos = remainingPositionsY[rand];
            remainingPositions.RemoveAt(rand);
            remainingPositionsY.RemoveAt(rand);
        }

        for (int k = 0; k < wave[waveIndex].spawnAmount; k++)
        {
            SpawnEnemy(xPos, yPos);
            rand = Random.Range(0, remainingPositions.Count);
            xPos = remainingPositions[rand];
            yPos = remainingPositionsY[rand];
            remainingPositions.RemoveAt(rand);
            remainingPositionsY.RemoveAt(rand);
        }
    }
}
