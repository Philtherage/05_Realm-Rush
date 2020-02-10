using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] ParticleSystem deathVFX;
    [SerializeField] ParticleSystem damageTakenVFX;



    GameObject deathParticles;

    Health health;
    

    private void Start()
    {
        deathParticles = GameObject.Find("Death Particles");
        health = GetComponent<Health>();
    }

    private void OnParticleCollision(GameObject other)
    {
        TakeDamage(other);
        Die();
    }

    private void TakeDamage(GameObject other)
    {
        int damage = other.GetComponent<DamageDealer>().GetDamage();
        health.TakeDamage(damage);
        damageTakenVFX.Play();
    }

    private void Die()
    {
        if (health.GetHealth() == 0)
        {
            Destroy(gameObject);
            ParticleSystem expolsion = Instantiate(deathVFX, transform.position, Quaternion.identity) as ParticleSystem;
            expolsion.gameObject.transform.parent = deathParticles.transform;
            Destroy(expolsion.gameObject, expolsion.main.duration);
        }
    }
}
