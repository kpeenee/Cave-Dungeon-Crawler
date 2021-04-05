using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightShot : Projectile
{
    
    void Update()
    {
        Move();
    }

    protected override void Move()
    {
        transform.position += transform.forward * projectileSpeed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            Health enemyHealth = other.gameObject.GetComponent<Health>();
            if (enemyHealth != null)
            {
                Debug.Log("Dealt " + damage);
                enemyHealth.takeDamage(damage);
            }
            GameObject deathParticle = Instantiate(destroyVFX, transform.position, Quaternion.identity);
            Destroy(deathParticle, 5.0f);
            Destroy(gameObject);
        }
    }
}
