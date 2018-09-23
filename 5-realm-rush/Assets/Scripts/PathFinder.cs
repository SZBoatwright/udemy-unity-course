using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour {

    [SerializeField] Waypoint startPoint, endPoint;
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    bool endFound = false;
    Waypoint searchCenter; // current searchCenter in loop
    List<Waypoint> path = new List<Waypoint>();
    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.down,
        Vector2Int.left,
        Vector2Int.right
    };

    public List<Waypoint> GetPath()
    {
        if(path.Count == 0)
        {
            CalculatePath();
        }
        return path;
    }

    private void CalculatePath()
    {
        LoadBlocks();
        ColorStartAndEnd();
        BreadthFirstSearch();
        CreatePath();
    }

    private void CreatePath()
    {
        AddToPath(endPoint);

        Waypoint previous = endPoint.exploredFrom;
        while(previous != startPoint)
        {
            AddToPath(previous);
            previous = previous.exploredFrom;
        }
        AddToPath(startPoint);
        path.Reverse();
    }

    private void AddToPath (Waypoint waypoint)
    {
        path.Add(waypoint);
        waypoint.isPlaceable = false;
    }

    private void BreadthFirstSearch()
    {
        queue.Enqueue(startPoint);
        while (queue.Count > 0 && !endFound)
        {
            searchCenter = queue.Dequeue(); // remove the queue's frontier and set it into a variable for reference
            searchCenter.isExplored = true;
            HaltIfEndFound();
            ExploreNeighbors();
        }
    }

    private void HaltIfEndFound()
    {
        if(searchCenter == endPoint)
        {
            endFound = true;
        }
    }

    private void ExploreNeighbors()
    {
        if (endFound) return;

        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighborCoordinates = searchCenter.GetGridPos() + direction;
            if(grid.ContainsKey(neighborCoordinates))
            {
                QueueNewNeighbors(neighborCoordinates);
            }
        }
    }

    private void QueueNewNeighbors(Vector2Int neighborCoordinates)
    {
        Waypoint neighbor = grid[neighborCoordinates];
        if(neighbor.isExplored == false && !queue.Contains(neighbor))
        {
            queue.Enqueue(neighbor);
            neighbor.exploredFrom = searchCenter;
        }
    }

    private void ColorStartAndEnd() //todo: consider moving out
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
            }
        }
    }
    
    void Update () {
		
	}
}
