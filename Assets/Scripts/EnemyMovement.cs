using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;
    public int groupIndex; // New: Index to identify the enemy group
    private Transform[] waypoints;
    private int waypointIndex = 0;

    void Start()
    {
        waypoints = WaypointManager.Instance.GetWaypoints();
        SetInitialWaypoint();
    }

    void Update()
    {
        Move();

        if (Vector3.Distance(transform.position, waypoints[waypointIndex].position) < 0.2f)
        {
            GetNextWaypoint();
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
            Destroy(gameObject);
        }
    }

    void SetInitialWaypoint()
    {
        transform.position = waypoints[waypointIndex].position;
    }
}

