using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Block> enemyPath;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Block block in enemyPath)
        {
            Debug.Log(block.transform.position.x + "," + block.transform.position.z);
        }
    }
}
