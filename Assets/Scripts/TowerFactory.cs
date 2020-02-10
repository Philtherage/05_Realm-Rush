using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;

    [Tooltip("The Number Of Towers Active at any given time")]
    [SerializeField] int numberOfActiveAllowed = 3;


    Queue<Tower> towers = new Queue<Tower>();
    Queue<Waypoint> waypoints = new Queue<Waypoint>();

    public void AddTowerToBuffer(Waypoint baseWaypoint)
    {
        if (towers.Count < numberOfActiveAllowed)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            print("Tower limit Reached");
            MoveTower(baseWaypoint);
        }
    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        Tower newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        var waypointPlacable = baseWaypoint;
        waypointPlacable.isPlaceable = false;
        waypoints.Enqueue(waypointPlacable);
        towers.Enqueue(newTower);
    }

    private void MoveTower(Waypoint location)
    {
        waypoints.Dequeue().isPlaceable = true;

        Tower oldTower = towers.Dequeue();
        oldTower.transform.position = location.transform.position;

        location.isPlaceable = false;
        waypoints.Enqueue(location);

        towers.Enqueue(oldTower);
        
    }

}
