using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{

    [SerializeField] Color exploredColor;


    public bool isExplored = false;
    public bool isPlaceable = true;

    public Waypoint exploredFrom;

    const int gridSize = 10;

    Vector2Int gridPos;

    // Update is called once per frame
    void Update()
    {
    }

    public Vector2Int GetGridPosition()
    {
        return new Vector2Int(
        Mathf.RoundToInt(transform.position.x / gridSize),
        Mathf.RoundToInt(transform.position.z / gridSize));
    }

    public int GetGridSize()
    {
        return gridSize;
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isPlaceable)
            {
                print("Placing Tower");
            }
            else
            {
                print("Cant Place At This Location");
            }

        }
        
    }
    
}
