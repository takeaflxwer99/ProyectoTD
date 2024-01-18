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
    public float startDelaySeconds = 2f; // Nueva variable para el retraso inicial

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
        StartCoroutine(StartEnemyGroups());
    }

    IEnumerator StartEnemyGroups()
    {
        yield return new WaitForSeconds(startDelaySeconds); // Agregamos un retraso inicial

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
