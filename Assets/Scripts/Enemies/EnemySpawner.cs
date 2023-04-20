using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    //esto todavia no se usa para nada. 


    public static EnemySpawner instance;

    [SerializeField]
    int numEnemies = 0;
    float minStatValue = 1f;
    float maxStatValue = 10f;

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
            Entity enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity)
                .SetHP(Random.Range(minStatValue, maxStatValue))
                .SetAttackDamage(Random.Range(minStatValue, maxStatValue))
                .SetSpeed(Random.Range(minStatValue, maxStatValue));


            //enemy.hp = Random.Range(minStatValue, maxStatValue);
            //enemy.attackDamage = Random.Range(minStatValue, maxStatValue);
            //enemy.speed = Random.Range(minStatValue, maxStatValue);
            enemy.transform.parent = this.transform;

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