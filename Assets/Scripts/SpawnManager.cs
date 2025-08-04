using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Enemy; // Enemy to spawn
    public GameObject [] spawnPoints; // List of spawn points in the level
    private float verticalSpawnRange = 5; // Vertical spawn position range
    private float horizontalSpawnRange = 10; // Horizontal spawn position range
    private float startDelay = 2; // Delay to start spawning enemies
    private float spawnInterval = 1.5f; // Spawn cooldown

    void Start()
    {
        // Continuosly spawn enemies
        InvokeRepeating("SpawnEnemy", startDelay, spawnInterval);
    }

    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        // Select a random spawn point
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        // Variables for position and rotation of the spawned enemy
        Vector2 spawnPos = new Vector2();
        Quaternion spawnRot = spawnPoints[spawnIndex].transform.rotation;
        // If the spawn point selected is a vertical one
        if (spawnPoints[spawnIndex].CompareTag("VerticalSpawn"))
        {
            // Calculate the enemy position within the horizontal range
            spawnPos = new Vector2(Random.Range(-horizontalSpawnRange, horizontalSpawnRange), spawnPoints[spawnIndex].transform.position.y);
        }
        // If the spawn point is a horizontal one
        else if (spawnPoints[spawnIndex].CompareTag("HorizontalSpawn"))
        {
            // Calculate the enemy position within the vertical range
            spawnPos = new Vector2(spawnPoints[spawnIndex].transform.position.x, Random.Range(-verticalSpawnRange, verticalSpawnRange));
        }
        // Spawn the enemy
        Instantiate(Enemy, spawnPos, spawnRot);
    }
}
