using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager sm; // Static reference of the spawn manager
    public GameObject enemyKamikaze; // Enemy to spawn
    public GameObject enemyStatic; // Enemy to spawn
    public GameObject powerUp; // Power Up to spawn
    public GameObject staticSpawn; // Spawn point for startic enemies
    public GameObject[] enemySpawnPoints; // List of enemy spawn points in the level
    private float verticalEnemySpawnRange = 5; // Vertical enemy spawn position range
    private float horizontalEnemySpawnRange = 10; // Horizontal enemy spawn position range
    private float enemySpawnStartDelay = 2; // Delay to start spawning enemies
    private float enemySpawnInterval = 2f; // Enemy spawn cooldown
    private int powerUpMaxCount = 5; // Max quantity of powerups in scene
    private int powerUpCount = 0; // Current quantity of power ups in scene
    private int killedEnemies = 0; // Killed enemies counter
    private int difficulty = 1; // Difficulty multiplier
    
    void Start()
    {
        if (sm != null && sm != this)
        {
            Destroy(gameObject); // Only one instance of spawn manager allowed
        }
        else
        {
            sm = this; // Inicialise the spawn manager instance
        }
        // Continuosly spawn enemies taking in account the difficulty
        InvokeRepeating("SpawnEnemyKamikazeX", enemySpawnStartDelay, enemySpawnInterval);
        InvokeRepeating("SpawnEnemyStaticX", 10f, 4f);
    }

    void Update()
    {
        // Update the killed enemies counter
        killedEnemies = GameManager.gm.KilledEnemiesCount();
        // Update difficulty accordingly
        DifficultyIncrease();
    }

    public void SpawnPowerUp(Vector3 position, Quaternion rotation)
    {
        // If the amount of power ups in the game is not the max
        if (powerUpCount < powerUpMaxCount)
        {
            // Calculate a random number for spawning power up
            int rn = Random.Range(0, 5);
            // 1 in 5 chances to spawn a power up
            if (rn == 3)
            {
                // Spawn a power up in a given position and rotation
                Instantiate(powerUp, position, rotation);
                powerUpCount++;
            }
        }
    }

    public void ConsumePowerUp()
    {
        // Consume a power up from the total amount
        if (powerUpCount > 0)
        {
            powerUpCount--;
        }
    }

    private void DifficultyIncrease()
    {
        if (killedEnemies >= 0 & killedEnemies < 20)
        {
            // If the amount of enemies killed is less than 20, set the difficulty to 1
            difficulty = 1;
        }
        if (killedEnemies >= 20 & killedEnemies < 60)
        {
            // If the amount of enemies killed is more than 20, but less than 60, set the difficulty to 2
            difficulty = 2;
        }
        if (killedEnemies >= 60 & killedEnemies < 120)
        {
            // If the amount of enemies killed is more than 60, but less than 120, set the difficulty to 3
            difficulty = 3;
        }
        if (killedEnemies >= 120)
        {
            // If the amount of enemies killed is more than 120, set the difficulty to 4
            difficulty = 4;
        }
    }

    private void SpawnEnemyKamikazeX()
    {
        // Spawn enemies taking in account the difficulty multiplier
        for (int i = 0; i < difficulty; i++)
        {
            // Select a random spawn point
            int spawnIndex = Random.Range(0, enemySpawnPoints.Length);
            // Variables for position and rotation of the spawned enemy
            Vector2 spawnPos = new Vector2();
            Quaternion spawnRot = enemySpawnPoints[spawnIndex].transform.rotation;
            // If the spawn point selected is a vertical one
            if (enemySpawnPoints[spawnIndex].CompareTag("VerticalSpawn"))
            {
                // Calculate the enemy position within the horizontal range
                spawnPos = new Vector2(Random.Range(-horizontalEnemySpawnRange, horizontalEnemySpawnRange), enemySpawnPoints[spawnIndex].transform.position.y);
            }
            // If the spawn point is a horizontal one
            else if (enemySpawnPoints[spawnIndex].CompareTag("HorizontalSpawn"))
            {
                // Calculate the enemy position within the vertical range
                spawnPos = new Vector2(enemySpawnPoints[spawnIndex].transform.position.x, Random.Range(-verticalEnemySpawnRange, verticalEnemySpawnRange));
            }
            // Spawn the enemy
            Instantiate(enemyKamikaze, spawnPos, spawnRot);
        }
    }

    private void SpawnEnemyStaticX()
    {
        // Spawn enemies taking in account the difficulty multiplier
        for (int i = 0; i < difficulty; i++)
        {
            // Select a random spawn point
            int spawnIndex = Random.Range(0, enemySpawnPoints.Length);
            // Variables for position and rotation of the spawned enemy
            Vector2 spawnPos = new Vector2(Random.Range(-8, 8), Random.Range(-3, 3));
            Quaternion spawnRot = staticSpawn.transform.rotation;
            // Play enemy spawn sound
            SoundManager.sm.PlaySound("StaticE_Spawn");
            // Spawn the enemy
            Instantiate(enemyStatic, spawnPos, spawnRot);
        }
    }
}
