using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;

    [Tooltip("Equiped Turret")]
    [SerializeField] ParticleSystem turret;

    [Tooltip("Shooting distance from enemy")] 
    [SerializeField] float turretRange = 10f;

    Enemy[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemies = FindObjectsOfType<Enemy>();
        CheckRange();
        objectToPan.LookAt(targetEnemy);
    }

    private void CheckRange()
    {
        List<float> distances = new List<float>();

        foreach(Enemy enemy in enemies)
        {
            float dist = Vector3.Distance(enemy.transform.position, gameObject.transform.position);
            distances.Add(dist);
        }
        IsEnemyInRange(distances);

    }

    private void IsEnemyInRange(List<float> distances)
    {
        
        foreach (float distance in distances)
        {
            if (distance <= turretRange)
            {
                var emissionModule = turret.emission;
                emissionModule.enabled = true;
            }
            else
            {
                var emissionModules = turret.emission;
                emissionModules.enabled = false;
            }
        }
        if(targetEnemy == null)
        {
            var emissionModule = turret.emission;
            emissionModule.enabled = false;
        }
       
    }
}
