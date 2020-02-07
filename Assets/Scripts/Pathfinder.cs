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
            searchCenter = queue.Dequeue();
            HaltIfEndFound();
            ExploreNeighbours();
            
        }
    }

    private void HaltIfEndFound()
    {
        if (searchCenter == end)
        {
            print("Found the end, Stopping search");
            isRunning = false;
        }
    }

    private void ExploreNeighbours()
    {
        if(!isRunning) { return; }
        foreach (Vector2Int direction in directions)
        {
            var explorationCorods = searchCenter.GetGridPosition() + direction;
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
        if(neighbour.isExplored || queue.Contains(neighbour)) { return; }

        queue.Enqueue(neighbour);
        neighbour.exploredFrom = searchCenter;
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
