using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;

    [SerializeField, Tooltip("The number of enemies to spawn.")]
    private int numEnemies = 5;
    
    [SerializeField, Tooltip("The min value for enemy stats.")]
    private float minStatValue = 1f;
    
    [SerializeField, Tooltip("The max value for enemy stats.")]
    private float maxStatValue = 10f;

    public Enemy enemyPrefab;


    int deadEnemyCount;
    public int enemyCountToNextLevel;
    //bool killedEnoughEnemies;

    public SpawnPoint[] spawnPoints;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {

        for (int i = 0; i < numEnemies; i++)
        {
            Enemy enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            enemy.hp = Random.Range(minStatValue, maxStatValue);
            enemy.attackDamage = Random.Range(minStatValue, maxStatValue);
            enemy.speed = Random.Range(minStatValue, maxStatValue);

            //randomPositions[i] = new Vector3(Random.value, 1, Random.value);
            enemy.transform.position = spawnPoints[i].transform.position;
        }
    }

    public void AddDeadEnemy()
    {
        print("enemyspawner: agrego deadenemy a la cueenta");

        deadEnemyCount++;

        if (deadEnemyCount >= enemyCountToNextLevel)
        {
            //killedEnoughEnemies = true;
            print("enemyspawner: mataste suficiente como para pasar de nivel");

        }
    }
}