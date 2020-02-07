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
        Vector2Int.down,
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.left
    };


    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        StartAndEndColor();
        Pathfind();
        ExploreNeighbours();
    }

    private void Pathfind()
    {
        queue.Enqueue(start);
        while(queue.Count > 0)
        {
            var searchCenter = queue.Dequeue();
            print(searchCenter);
            HaltIfEndFound(searchCenter);
        }
    }

    private void HaltIfEndFound(Waypoint searchCenter)
    {
        if (searchCenter == end)
        {
            print("terminating action ");
            isRunning = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ExploreNeighbours()
    {
        foreach (Vector2Int direction in directions)
        {
            var explorationCorods = start.GetGridPosition() + direction;
            try
            {
                grid[explorationCorods].SetTopColor(Color.green);
            }
            catch
            {
               
            }
        }
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
