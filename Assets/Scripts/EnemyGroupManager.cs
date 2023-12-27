using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class EnemyGroupManager : MonoBehaviour
{
    public static EnemyGroupManager Instance;

    public GameObject enemyPrefab;
    public int enemiesPerGroup = 5;
    public float timeBetweenGroups = 5f;
    public float distanceBetweenEnemiesInGroup = 2f;
    public Vector3 enemyScale = new Vector3(1f, 1f, 1f);

    public int totalGroupsToSpawn = 3; // Número total de grupos a generar
    private int spawnedGroups = 0; // Número de grupos generados hasta ahora

    private Transform spawnPoint;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        spawnPoint = transform;
        StartCoroutine(SpawnEnemyGroups());
    }

    IEnumerator SpawnEnemyGroups()
    {
        while (spawnedGroups < totalGroupsToSpawn)
        {
            SpawnEnemyGroup();
            yield return new WaitForSeconds(timeBetweenGroups);
            spawnedGroups++;
        }
    }

    void SpawnEnemyGroup()
    {
        Vector3 startPosition = spawnPoint.position;

        for (int i = 0; i < enemiesPerGroup; i++)
        {
            Vector3 offset = Vector3.right * i * distanceBetweenEnemiesInGroup;
            InstantiateEnemy(startPosition + offset);
        }
    }

    void InstantiateEnemy(Vector3 position)
    {
        GameObject enemyInstance = Instantiate(enemyPrefab, position, Quaternion.identity);
        enemyInstance.transform.localScale = enemyScale;
    }
}


//public class EnemyGroupManager : MonoBehaviour
//{
//    public static EnemyGroupManager Instance;

//    public GameObject enemyPrefab; // Prefab de enemigo
//    public int enemiesPerGroup = 5; // Número de enemigos por grupo
//    public float timeBetweenGroups = 5f; // Tiempo entre grupos
//    public float distanceBetweenEnemiesInGroup = 2f; // Distancia entre enemigos en el mismo grupo
//    public Vector3 enemyScale = new Vector3(1f, 1f, 1f); // Escala de los enemigos

//    private Transform spawnPoint;

//    void Awake()
//    {
//        Instance = this;
//    }

//    void Start()
//    {
//        spawnPoint = transform; // Puedes ajustar esto según la posición deseada

//        // Llama a la función para iniciar la generación de enemigos
//        StartCoroutine(SpawnEnemyGroups());
//    }

//    IEnumerator SpawnEnemyGroups()
//    {
//        while (true)
//        {
//            SpawnEnemyGroup();
//            yield return new WaitForSeconds(timeBetweenGroups);
//        }
//    }

//    void SpawnEnemyGroup()
//    {
//        Vector3 startPosition = spawnPoint.position;

//        for (int i = 0; i < enemiesPerGroup; i++)
//        {
//            Vector3 offset = Vector3.right * i * distanceBetweenEnemiesInGroup;
//            InstantiateEnemy(startPosition + offset);
//        }
//    }

//    void InstantiateEnemy(Vector3 position)
//    {
//        GameObject enemyInstance = Instantiate(enemyPrefab, position, Quaternion.identity);
//        enemyInstance.transform.localScale = enemyScale;

//        // Puedes agregar lógica adicional aquí, si es necesario
//    }
//}
//public class EnemyGroupManager : MonoBehaviour
//{
//    public static EnemyGroupManager Instance;

//    public GameObject[] enemyPrefabs;
//    public int[] numberOfEnemies;

//    void Awake()
//    {
//        Instance = this;
//    }

//    public void SpawnEnemyGroup(Transform spawnPoint, int startingLevel)
//    {
//        for (int i = 0; i < enemyPrefabs.Length; i++)
//        {
//            for (int j = 0; j < numberOfEnemies[i]; j++)
//            {
//                GameObject enemyPrefab = enemyPrefabs[i];
//                InstantiateEnemy(enemyPrefab, spawnPoint.position, startingLevel + j);
//            }
//        }
//    }

//    void InstantiateEnemy(GameObject enemyPrefab, Vector3 position, int level)
//    {
//        GameObject enemyInstance = Instantiate(enemyPrefab, position, Quaternion.identity);
//        EnemyMovement enemyMovement = enemyInstance.GetComponent<EnemyMovement>();

//        if (enemyMovement != null)
//        {
//            enemyMovement.SetWaypoints(WaypointManager.waypoints);
//            enemyMovement.SetLevel(level);
//        }
//        else
//        {
//            Debug.LogError("Enemy prefab is missing EnemyMovement component.");
//        }
//    }
//}


//public class EnemyGroupManager : MonoBehaviour
//{
//    public static EnemyGroupManager Instance;

//    public GameObject enemyPrefab;
//    public int totalEnemiesPerGroup = 4;

//    void Awake()
//    {
//        Instance = this;
//    }

//    public void SpawnEnemyGroup(Transform spawnPoint)
//    {
//        for (int i = 0; i < totalEnemiesPerGroup; i++)
//        {
//            GameObject enemyInstance = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
//            EnemyMovement enemyMovement = enemyInstance.GetComponent<EnemyMovement>();

//            if (enemyMovement != null)
//            {
//                enemyMovement.SetWaypoints(WaypointManager.GetWaypoints());
//            }
//            else
//            {
//                Debug.LogError("Enemy prefab is missing EnemyMovement component.");
//            }
//        }
//    }
//}
