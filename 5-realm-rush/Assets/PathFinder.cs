using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour {

    [SerializeField] Waypoint startPoint, endPoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    Queue<Waypoint> queue = new Queue<Waypoint>();

    bool endFound = false;

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.down,
        Vector2Int.left,
        Vector2Int.right
    };

    void Start () {
        LoadBlocks();
        ColorStartAndEnd();
        FindPath();
	}

    private void FindPath()
    {
        queue.Enqueue(startPoint);
        while (queue.Count > 0 && !endFound)
        {
            var searchCenter = queue.Dequeue(); // remove the queue's frontier and set it into a variable for reference
            searchCenter.isExplored = true;
            print("searching from " + searchCenter);
            HaltIfEndFound(searchCenter);
            ExploreNeighbors(searchCenter);
        }
        print("finished pathfinding");
    }

    private void HaltIfEndFound(Waypoint searchCenter)
    {
        if(searchCenter == endPoint)
        {
            print("endpoint found");
            endFound = true;
        }
    }

    private void ExploreNeighbors(Waypoint from)
    {
        if (endFound) return;

        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighborCoordinates = from.GetGridPos() + direction;
            print("exploring " + neighborCoordinates);
            try
            {
                QueueNewNeighbors(neighborCoordinates);
            }
            catch
            {
                // do nothing
            }
        }
    }

    private void QueueNewNeighbors(Vector2Int neighborCoordinates)
    {
        Waypoint neighbor = grid[neighborCoordinates];
        if(neighbor.isExplored == false)
        {
            queue.Enqueue(neighbor);
            neighbor.SetTopColor(Color.blue);
            print("enqueueing " + neighbor);
        }
    }

    private void ColorStartAndEnd()
    {
        startPoint.SetTopColor(Color.green);
        endPoint.SetTopColor(Color.red);
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
                waypoint.SetTopColor(Color.black);
            }
        }
    }
    
    void Update () {
		
	}
}
