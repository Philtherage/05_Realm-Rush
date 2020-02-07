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

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };


    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        StartAndEndColor();
        Pathfind();
    }

    private void Pathfind()
    {
        queue.Enqueue(start);
        while(queue.Count > 0 && isRunning)
        {
            var searchCenter = queue.Dequeue();
            HaltIfEndFound(searchCenter);
            ExploreNeighbours(searchCenter);
            
        }
    }

    private void HaltIfEndFound(Waypoint searchCenter)
    {
        if (searchCenter == end)
        {
            print("Found the end, Stopping search");
            isRunning = false;
        }
    }

    private void ExploreNeighbours(Waypoint from)
    {
        if(!isRunning) { return; }
        foreach (Vector2Int direction in directions)
        {
            var explorationCorods = from.GetGridPosition() + direction;
            try
            {
                QueueNewNeighbours(explorationCorods);
            }
            catch
            {
               
            }
        }
    }

    private void QueueNewNeighbours(Vector2Int explorationCorods)
    {
        Waypoint neighbour = grid[explorationCorods];
        if(neighbour.isExplored) { return; }
        neighbour.SetTopColor(Color.green);
        queue.Enqueue(neighbour);
        neighbour.isExplored = true;
        print("neibours " + neighbour);
    }

    private void LoadBlocks()
    {
        Waypoint[] waypoints = FindObjectsOfType<Waypoint>();
        foreach(Waypoint waypoint in waypoints)
        {
            bool isOverlapping = grid.ContainsKey(waypoint.GetGridPosition());
            if (isOverlapping)
            {
                Debug.Log("Skipping overlapping block " + waypoint);                
            }
            else
            {
                grid.Add(waypoint.GetGridPosition(), waypoint);                
            }
        }       
    }

    private void StartAndEndColor()
    {
        start.SetTopColor(Color.green);
        end.SetTopColor(Color.red);
    }

}
