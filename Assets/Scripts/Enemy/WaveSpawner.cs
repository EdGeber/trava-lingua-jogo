using UnityEngine;
using System;
[System.Serializable]

public class WaveSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    [NonSerialized]
    public int waveNumber = 1;
    private TL TL;
    private bool GameIsPaused { get => PauseBehaviour.GameIsPaused; }
    [SerializeField]
    private EnemyBase enemyPrefab;

    [SerializeField]
    private float maxSpawnInterval = 2.5f;
    [SerializeField]
    private float minSpawnInterval = 0.1f;
    [SerializeField]
    private float spawnIntervalDecreasePerWave = 0.2f;
    [SerializeField]
    private float intervalBetweenWaves = 7f;

    void Start() {
        TL = GameObject.Find("/System/TL").GetComponent<TL>();
        SpawnWaves();
    }

    void SpawnWaves() {
        float numEnemies = waveNumber;
        float spawnInterval = Math.Max(
            maxSpawnInterval - spawnIntervalDecreasePerWave*waveNumber,
            minSpawnInterval
        );
        float waveDuration = (numEnemies-1)*spawnInterval + intervalBetweenWaves;

        for(int i=0; i<numEnemies; i++) {
            EnemyBase randomEnemy = enemyPrefab;  //TODO: change to an actual random enemy
            Transform RandomPoint = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)];
            TL.runAfterDelay(
                () => Instantiate(randomEnemy, RandomPoint.position, Quaternion.identity),
                i*spawnInterval
            );
        }
        waveNumber++;
        TL.runAfterDelay(() => SpawnWaves(), waveDuration);
    }
}
