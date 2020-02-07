using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float timeBetweenGrids = 1f;

    List<Waypoint> path;
    // Start is called before the first frame update
    void Start()
    {
        path = FindObjectOfType<Pathfinder>().GetPath();
        StartCoroutine(MoveOnPath());
    }

    IEnumerator MoveOnPath()
    {
        foreach (Waypoint waypoint in path)
        {
            print(waypoint.gameObject.name);
            transform.position = new Vector3(waypoint.transform.position.x, 
                                             transform.position.y, waypoint.transform.position.z);
            yield return new WaitForSeconds(timeBetweenGrids);
        }
        
    }

}
