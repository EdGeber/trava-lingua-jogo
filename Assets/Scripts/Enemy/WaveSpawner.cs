using UnityEngine;
[System.Serializable]

public class Wave {
    public string waveName;
    public int enemyCount;
    public GameObject[] Enemy;
    public float spawnInterval;
}

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] Wave[] waves;
    public Transform[] spawnPoints;

    private Wave currentWave;
    private int currentWaveNumber;
    private float nextSpawnTime;
    private bool canSpawn = true;
    private bool gameIsPaused = PauseBehaviour.gameIsPaused;

    private void Update(){
        if (!gameIsPaused)
        {
            currentWave = waves[currentWaveNumber];
            SpawnWave();
            GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");
            if(totalEnemies.Length == 0 && !canSpawn && (currentWaveNumber+1) != waves.Length){
                SpawnNextWave();
            }
        }
    }
    void SpawnNextWave(){
        currentWaveNumber++;
        canSpawn = true;
    }

    void SpawnWave(){
        if(canSpawn && nextSpawnTime < Time.time){
            GameObject randomEnemy = currentWave.Enemy[0];
            Transform RandomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(randomEnemy, RandomPoint.position, Quaternion.identity);
            currentWave.enemyCount--;
            nextSpawnTime = Time.time + currentWave.spawnInterval;
            if(currentWave.enemyCount == 0){
                canSpawn = false;
            }
        }   
    }
}
