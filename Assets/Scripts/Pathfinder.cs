using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    [SerializeField] Waypoint start;
    [SerializeField] Waypoint end;

    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        StartAndEndColor();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        
        print("Loaded " + grid.Count + " Blocks");        
    }

    private void StartAndEndColor()
    {
        start.SetTopColor(Color.green);
        end.SetTopColor(Color.red);
    }

}
