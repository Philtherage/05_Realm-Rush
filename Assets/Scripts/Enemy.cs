using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int ScorePoints = 10;
    [SerializeField] ParticleSystem deathVFX;
    [SerializeField] ParticleSystem damageTakenVFX;
    [SerializeField] AudioClip deathSFX;

    GameObject deathParticles;
    Health health;


    private void Start()
    {
        deathParticles = GameObject.Find("Death Particles");
        health = GetComponent<Health>();
    }

    private void OnTriggerEnter(Collider other)
    {
        DealDamageAndDie();
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
            FindObjectOfType<Score>().AddToScore(ScorePoints);
            AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position);
            ParticleSystem expolsion = Instantiate(deathVFX, transform.position, Quaternion.identity) as ParticleSystem;
            expolsion.gameObject.transform.parent = deathParticles.transform;
            Destroy(expolsion.gameObject, expolsion.main.duration);
        }
    }

    private void DealDamageAndDie()
    {
        FindObjectOfType<BaseHealth>().DamageBase(GetComponent<DamageDealer>().GetDamage());
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position);
        ParticleSystem expolsion = Instantiate(deathVFX, transform.position, Quaternion.identity) as ParticleSystem;
        expolsion.gameObject.transform.parent = deathParticles.transform;
        Destroy(expolsion.gameObject, expolsion.main.duration);
    }
}
