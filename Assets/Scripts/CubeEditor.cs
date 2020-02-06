using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour
{

    [Range(1f, 20f)][SerializeField] float gridSize = 10f;


    TextMesh gridText;
    private void Start()
    {
        gridText = GetComponentInChildren<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
        transform.position = new Vector3(snapPos.x, 0f, snapPos.z);

        gridText.text = transform.position.x / gridSize + "," + transform.position.z / gridSize;
        gameObject.name = gridText.text;
    }
}
