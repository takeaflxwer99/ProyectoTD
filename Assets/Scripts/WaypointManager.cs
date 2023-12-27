using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class WaypointManager : MonoBehaviour
{
    public static WaypointManager Instance;
    public Transform[] waypoints;

    void Awake()
    {
        Instance = this;
        InitializeWaypoints();
    }

    void InitializeWaypoints()
    {
        waypoints = new Transform[transform.childCount];

        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = transform.GetChild(i);
        }
    }

    public Transform[] GetWaypoints()
    {
        return waypoints;
    }
}


//public class WaypointManager : MonoBehaviour
//{
//    public static WaypointManager Instance;

//    // Array de puntos de destino
//    public static Transform[] waypoints;

//    void Awake()
//    {
//        Instance = this;
//        InitializeWaypoints();
//    }

//    void InitializeWaypoints()
//    {
//        // Obtener todos los puntos de destino hijos del objeto WaypointManager
//        waypoints = new Transform[transform.childCount];

//        for (int i = 0; i < waypoints.Length; i++)
//        {
//            waypoints[i] = transform.GetChild(i);
//        }
//    }

//    public Transform[] GetWaypoints()
//    {
//        return waypoints;
//    }
//}

//public class WaypointManager : MonoBehaviour
//{
//    public static Transform[][] waypoints;

//    void Awake()
//    {
//        InitializeWaypoints();
//    }

//    void Start()
//    {
//        // Cualquier código de inicialización adicional puede ir aquí
//    }

//    void InitializeWaypoints()
//    {
//        int levels = transform.childCount;
//        waypoints = new Transform[levels][];

//        for (int i = 0; i < levels; i++)
//        {
//            Transform levelTransform = transform.GetChild(i);
//            waypoints[i] = new Transform[levelTransform.childCount];

//            for (int j = 0; j < waypoints[i].Length; j++)
//            {
//                waypoints[i][j] = levelTransform.GetChild(j);
//            }
//        }
//    }
//}