using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class EnemyGroupManager : MonoBehaviour
{
    public static EnemyGroupManager Instance;

    public GameObject[] enemyPrefabs;
    public int enemiesPerGroup = 5;
    public float timeBetweenGroups = 5f;
    public float timeBetweenEnemies = 1f;

    [Header("Events")]
    public static UnityEvent onEnemyDestroy = new UnityEvent();
    public static UnityEvent onLastWaveDestroyed = new UnityEvent();

    public List<ScaleStage> scaleStages = new List<ScaleStage>();

    [System.Serializable]
    public struct ScaleStage
    {
        public Vector3 scale;
    }

    public List<Vector3> groupScales = new List<Vector3>();

    public int totalGroupsToSpawn = 8;
    private int spawnedGroups = 0;

    private Transform spawnPoint;

    private int currentEnemyPrefabIndex = 0;

    void Awake()
    {
        Instance = this;

        while (groupScales.Count < totalGroupsToSpawn)
        {
            groupScales.Add(Vector3.one);
        }
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

        onLastWaveDestroyed.Invoke();
    }

    void SpawnEnemyGroup()
    {
        Vector3 startPosition = spawnPoint.position;
        startPosition.Scale(groupScales[spawnedGroups]);

        for (int i = 0; i < enemiesPerGroup; i++)
        {
            Vector3 offset = Vector3.right * i * 2f;

            GameObject currentEnemyPrefab = enemyPrefabs[currentEnemyPrefabIndex];
            Vector3 currentScale = scaleStages[i % scaleStages.Count].scale;
            currentScale.Scale(groupScales[spawnedGroups]);

            StartCoroutine(SpawnEnemyWithDelay(startPosition + offset, currentEnemyPrefab, currentScale, i * timeBetweenEnemies));
        }

        currentEnemyPrefabIndex = (currentEnemyPrefabIndex + 1) % enemyPrefabs.Length;
    }

    IEnumerator SpawnEnemyWithDelay(Vector3 spawnPosition, GameObject enemyPrefab, Vector3 enemyScale, float delay)
    {
        yield return new WaitForSeconds(delay);

        GameObject enemyInstance = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        enemyInstance.transform.localScale = enemyScale;

        EnemyMovement enemyMovement = enemyInstance.GetComponent<EnemyMovement>();
        if (enemyMovement != null)
        {
            enemyMovement.groupIndex = spawnedGroups;
        }
    }

    void OnEnemyDestroy()
    {
        onEnemyDestroy.Invoke();

        if (AllEnemiesDestroyed())
        {
            onLastWaveDestroyed.Invoke();
        }
    }

    bool AllEnemiesDestroyed()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();
            if (enemyMovement != null && enemyMovement.groupIndex == spawnedGroups)
            {
                return false;
            }
        }

        return true;
    }
}




//    public GameObject enemyPrefab;
//    public int enemiesPerGroup = 5;
//    public float timeBetweenGroups = 5f;
//    public float distanceBetweenEnemiesInGroup = 2f;
//    public Vector3 enemyScale = new Vector3(1f, 1f, 1f);

//    public int totalGroupsToSpawn = 3; // N�mero total de grupos a generar
//    private int spawnedGroups = 0; // N�mero de grupos generados hasta ahora

//    private Transform spawnPoint;

//    void Awake()
//    {
//        Instance = this;
//    }

//    void Start()
//    {
//        spawnPoint = transform;
//        StartCoroutine(SpawnEnemyGroups());
//    }

//    IEnumerator SpawnEnemyGroups()
//    {
//        while (spawnedGroups < totalGroupsToSpawn)
//        {
//            SpawnEnemyGroup();
//            yield return new WaitForSeconds(timeBetweenGroups);
//            spawnedGroups++;
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
//    }
//}


//public class EnemyGroupManager : MonoBehaviour
//{
//    public static EnemyGroupManager Instance;

//    public GameObject enemyPrefab; // Prefab de enemigo
//    public int enemiesPerGroup = 5; // N�mero de enemigos por grupo
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
//        spawnPoint = transform; // Puedes ajustar esto seg�n la posici�n deseada

//        // Llama a la funci�n para iniciar la generaci�n de enemigos
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

//        // Puedes agregar l�gica adicional aqu�, si es necesario
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
