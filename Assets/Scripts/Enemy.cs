using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] ParticleSystem deathVFX;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        int damage = other.GetComponent<DamageDealer>().GetDamage();
        Health health = GetComponent<Health>();
        health.TakeDamage(damage);
        if(health.GetHealth() == 0)
        {
            Destroy(gameObject);
            ParticleSystem expolsion = Instantiate(deathVFX, transform.position, Quaternion.identity) as ParticleSystem;
            Destroy(expolsion, 1f);
        }
    }
}
