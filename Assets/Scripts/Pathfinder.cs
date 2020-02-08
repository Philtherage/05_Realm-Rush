using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Waypoint start, end;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    bool isRunning = true;
    Waypoint searchCenter;
    List<Waypoint> path = new List<Waypoint>();
    bool calledOnce = false;

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    public List<Waypoint> GetPath()
    {
        if (calledOnce) { return path; }
        LoadBlocks();
        BreadthFirstSearch();
        CreatePath();
        calledOnce = true;
        return path;
    }

    private void CreatePath()
    {
        SetAsPath(end);
        Waypoint previous = end.exploredFrom;
        while(previous != start)
        {
            // add intermediate waypoints
            SetAsPath(previous);            
            // gets previous location and stores it threw to start then end of loop
            previous = previous.exploredFrom;
            
        }
        SetAsPath(start);
        path.Reverse();   
    }

    private void SetAsPath(Waypoint waypoint)
    {
        path.Add(waypoint);
        waypoint.isPlaceable = false;
    }

    private void BreadthFirstSearch()
    {
        queue.Enqueue(start);
        while(queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            HaltIfEndFound();
            ExploreNeighbours();
            
        }
    }

    private void HaltIfEndFound()
    {
        if (searchCenter == end)
        {
            isRunning = false;
        }
    }

    private void ExploreNeighbours()
    {
        if(!isRunning) { return; }
        foreach (Vector2Int direction in directions)
        {
            var explorationCorods = searchCenter.GetGridPosition() + direction;
            if(grid.ContainsKey(explorationCorods))
            {
                QueueNewNeighbours(explorationCorods);
            }
        }
    }

    private void QueueNewNeighbours(Vector2Int explorationCorods)
    {
        Waypoint neighbour = grid[explorationCorods];
        if(neighbour.isExplored || queue.Contains(neighbour)) { return; }

        queue.Enqueue(neighbour);
        neighbour.exploredFrom = searchCenter;
        neighbour.isExplored = true;
    }

    private void LoadBlocks()
    {
        Waypoint[] waypoints = FindObjectsOfType<Waypoint>();
        foreach(Waypoint waypoint in waypoints)
        {
            bool isOverlapping = grid.ContainsKey(waypoint.GetGridPosition());
            if (isOverlapping)
            {
                // do nothing
            }
            else
            {
                grid.Add(waypoint.GetGridPosition(), waypoint);                
            }
        }       
    }

}
