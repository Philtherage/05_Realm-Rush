﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public bool isExplored = false;
    public bool isPlaceable = true;
    public Waypoint exploredFrom;

    [SerializeField] Tower towerPrefab;

    const int gridSize = 10;

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
                Instantiate(towerPrefab, transform.position, Quaternion.identity);
                isPlaceable = false;
            }
            else
            {
                print("Cant Place At This Location");
            }
        }        
    }
}
