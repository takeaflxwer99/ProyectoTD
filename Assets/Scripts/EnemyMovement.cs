using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;
    public int groupIndex;
    private Transform[] waypoints;
    private int waypointIndex = 0;

    private bool isLastWaveDestroyed = false;

    void Start()
    {
        waypoints = WaypointManager.Instance.GetWaypoints();
        SetInitialWaypoint();

        EnemyGroupManager.onLastWaveDestroyed.AddListener(OnLastWaveDestroyed);
    }

    void OnDestroy()
    {
        EnemyGroupManager.onLastWaveDestroyed.RemoveListener(OnLastWaveDestroyed);
    }

    void Update()
    {
        if (!isLastWaveDestroyed)
        {
            Move();

            if (Vector3.Distance(transform.position, waypoints[waypointIndex].position) < 0.2f)
            {
                GetNextWaypoint();
            }
        }
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].position, speed * Time.deltaTime);
    }

    void GetNextWaypoint()
    {
        if (waypointIndex < waypoints.Length - 1)
        {
            waypointIndex++;
        }
        else
        {
            PerformLastWaypointAction();
            Destroy(gameObject);
        }
    }

    void SetInitialWaypoint()
    {
        transform.position = waypoints[waypointIndex].position;
    }

    void OnLastWaveDestroyed()
    {
        isLastWaveDestroyed = true;
    }

    void PerformLastWaypointAction()
    {
        Debug.Log("Enemigo llegó al último waypoint y la última oleada está destruida");
    }
}
