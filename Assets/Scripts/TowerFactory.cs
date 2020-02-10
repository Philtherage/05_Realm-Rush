using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;

    [Tooltip("The Number Of Towers Active at any given time")]
    [SerializeField] int numberOfActiveAllowed = 3;


    GameObject Towers;
    Queue<Tower> towers = new Queue<Tower>();

    private void Start()
    {
        Towers = new GameObject("Towers");
    }

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
        Tower newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity) as Tower;
        newTower.transform.parent = Towers.transform;
        newTower.baseWaypoint = baseWaypoint;
        newTower.baseWaypoint.isPlaceable = false;
        
        towers.Enqueue(newTower);
    }

    private void MoveTower(Waypoint newBaseWaypoint)
    {
        Tower oldTower = towers.Dequeue();

        oldTower.baseWaypoint.isPlaceable = true;
        newBaseWaypoint.isPlaceable = false;
        oldTower.baseWaypoint = newBaseWaypoint;

        oldTower.transform.position = newBaseWaypoint.transform.position;
        towers.Enqueue(oldTower);
        
    }

}
