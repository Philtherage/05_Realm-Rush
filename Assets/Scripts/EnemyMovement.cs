using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Waypoint> enemyPath;
    [SerializeField] float timeBetweenGrids = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveOnPath());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator MoveOnPath()
    {
        print("Starting Patrol...");
        foreach (Waypoint waypoint in enemyPath)
        {            
            print("Visiting block: " + waypoint.name);
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(timeBetweenGrids);
        }
        print("Ending Patrol");
    }


}
