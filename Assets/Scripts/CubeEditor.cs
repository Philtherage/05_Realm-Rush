using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
    Waypoint waypoint;

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    // Update is called once per frame
    void Update()
    {
        SnapToGrid();
        UpdateGridText();
    }

    private void UpdateGridText()
    {
        TextMesh gridText = GetComponentInChildren<TextMesh>();
        int gridSize = waypoint.GetGridSize();
        gridText.text = transform.position.x / gridSize + "," + transform.position.z / gridSize;
        gameObject.name = gridText.text;
    }

    private void SnapToGrid()
    {
        transform.position = new Vector3(waypoint.GetGridPosition().x,
                                            0f, waypoint.GetGridPosition().y);
    }
}
