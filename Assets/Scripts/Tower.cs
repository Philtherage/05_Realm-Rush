using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // Paramaters of each tower
    [SerializeField] Transform objectToPan;
    [Tooltip("Equiped Turret")]
    [SerializeField] ParticleSystem turret;
    [Tooltip("Shooting distance from enemy")] 
    [SerializeField] float turretRange = 40f;
    
    // State of each Tower
    [SerializeField] Transform targetEnemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetTargetEnemy();
        if (targetEnemy)
        {
            FireAtEnemy();       
        }
        else
        {
            Shoot(false);
        }

    }

    private void FireAtEnemy()
    {                  
       float distance = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
       if (distance <= turretRange)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

    private void Shoot(bool inRange)
    {
        var emissionModule = turret.emission;  
        emissionModule.enabled = inRange;
        objectToPan.LookAt(targetEnemy);
    }

    private void SetTargetEnemy()
    {
        var enemies = FindObjectsOfType<Enemy>();
        if(enemies.Length == 0) { return; }

        Transform closestEnemy = enemies[0].transform;

        foreach(Enemy enemy in enemies)
        {
            closestEnemy = GetClosestEnemy(closestEnemy, enemy.transform);
        }

        targetEnemy = closestEnemy;
    }

    private Transform GetClosestEnemy(Transform closestEnemy, Transform enemy)
    {
        float distance1 = Vector3.Distance(closestEnemy.position, transform.position);
        float distance2 = Vector3.Distance(enemy.position, transform.position);

        if (distance2 < distance1) { return enemy; }
        return closestEnemy;
    }
}
