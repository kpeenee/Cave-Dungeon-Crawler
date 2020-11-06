using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : Projectile
{
    void Update()
    {
        Move();
    }

    protected override void Move()
    {
        transform.position += transform.forward * projectileSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        
    }
}
