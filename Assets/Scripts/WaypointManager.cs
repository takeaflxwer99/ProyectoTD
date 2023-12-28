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
