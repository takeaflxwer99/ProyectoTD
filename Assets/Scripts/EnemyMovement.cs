using System.Collections;
using System.Collections.Generic;
using UnityEngine;






public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;
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
//public class EnemyMovement : MonoBehaviour
//{
//    public float speed = 2f; // Ajusta la velocidad según tus necesidades
//    public float distanceBetweenEnemiesInGroup = 2f; // Distancia entre cada enemigo en el grupo
//    private Transform[] waypoints;
//    private int waypointIndex = 0;

//    void Start()
//    {
//        waypoints = WaypointManager.Instance.GetWaypoints(); // Obtén los waypoints de WaypointManager
//        SetInitialWaypoint();
//    }

//    void Update()
//    {
//        Move();

//        if (Vector3.Distance(transform.position, waypoints[waypointIndex].position) < 0.2f)
//        {
//            GetNextWaypoint();
//        }
//    }

//    void Move()
//    {
//        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].position, speed * Time.deltaTime);
//    }

//    void GetNextWaypoint()
//    {
//        if (waypointIndex < waypoints.Length - 1)
//        {
//            waypointIndex++;
//        }
//        else
//        {
//            Destroy(gameObject);
//        }
//    }

//    void SetInitialWaypoint()
//    {
//        // Asigna el primer punto de destino al enemigo
//        transform.position = waypoints[waypointIndex].position;
//    }
//}
////public class EnemyMovement : MonoBehaviour
////{
////    public float speed = 5f;
////    public Transform[][] waypoints;
////    public int waypointIndex = 0;
////    private int level = 1;
////    public float sizeMultiplier = 1.0f;
////    public float distanceBetweenEnemies = 2.0f;

////    public void SetWaypoints(Transform[][] newWaypoints)
////    {
////        waypoints = newWaypoints;
////}

////    public void SetLevel(int newLevel)
////    {
////        level = newLevel;
////    }

////    void Start()

////     {
////            Debug.Log($"EnemyMovement Start - Level: {level}, Waypoint Index: {waypointIndex}");

////            if (waypoints != null)
////            {
////                Debug.Log($"Waypoints Length: {waypoints.Length}");

////                if (level - 1 >= 0 && level - 1 < waypoints.Length && waypoints[level - 1] != null)
////                {
////                    Debug.Log($"Waypoints[level - 1] Length: {waypoints[level - 1].Length}");

////                    if (waypointIndex >= 0 && waypointIndex < waypoints[level - 1].Length)
////                    {
////                        transform.position = waypoints[level - 1][waypointIndex].position;

////                        Vector3 offset = new Vector3(level * distanceBetweenEnemies, 0f, 0f);
////                        transform.position += offset;
////                    }
////                    else
////                    {
////                        Debug.LogError("Invalid waypoint index for enemy.");
////                        Destroy(gameObject);
////                    }
////                }
////                else
////                {
////                    Debug.LogError("Invalid level or null waypoints[level - 1] for enemy.");
////                    Destroy(gameObject);
////                }
////            }
////            else
////            {
////                Debug.LogError("Waypoints array is null.");
////                Destroy(gameObject);
////            }
////        }

////        void Update()
////    {
////        Move();

////        if (waypoints != null && level - 1 < waypoints.Length && waypointIndex < waypoints[level - 1].Length &&
////            Vector3.Distance(transform.position, waypoints[level - 1][waypointIndex].position) < 0.2f)
////        {
////            GetNextWaypoint();
////        }
////    }

////    void Move()
////    {
////        if (waypoints != null && level - 1 < waypoints.Length && waypointIndex < waypoints[level - 1].Length)
////        {
////            transform.position = Vector3.MoveTowards(transform.position, waypoints[level - 1][waypointIndex].position, speed * Time.deltaTime);
////        }
////    }

////    void GetNextWaypoint()
////    {
////        if (waypoints != null && level - 1 < waypoints.Length && waypointIndex < waypoints[level - 1].Length - 1)
////        {
////            waypointIndex++;
////        }
////        else
////        {
////            Destroy(gameObject);
////        }
////    }
////}
////public float speed = 5f;
////private Transform[] waypoints;
////private int waypointIndex = 0;

////void Update()
////{
////    Move();

////    if (Vector3.Distance(transform.position, waypoints[waypointIndex].position) < 0.2f)
////    {
////        GetNextWaypoint();
////    }
////}

////void Move()
////{
////    transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].position, speed * Time.deltaTime);
////}

////void GetNextWaypoint()
////{
////    if (waypointIndex < waypoints.Length - 1)
////    {
////        waypointIndex++;
////    }
////    else
////    {
////        Destroy(gameObject);
////    }
////}

////public void SetWaypoints(Transform[] newWaypoints)
////{
////    waypoints = newWaypoints;
////}

