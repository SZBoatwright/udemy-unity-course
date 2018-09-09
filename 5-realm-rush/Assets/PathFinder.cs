using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour {

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

	void Start () {
        LoadBlocks();
	}

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();
            
            if (grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("skipped duplicate block: " + waypoint);
            } else
            {
            grid.Add(gridPos, waypoint);
            }
        }
        print("loaded " + grid.Count + " blocks");
    }
    
    void Update () {
		
	}
}
