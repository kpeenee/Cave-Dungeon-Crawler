using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] protected string projectileName;
    [SerializeField] protected float projectileSpeed;
    [SerializeField] protected int projectileAmount;
    [SerializeField] protected float damage;
    [SerializeField] protected AudioClip shootSound;
    [SerializeField] protected GameObject destroyVFX;

    protected void Start()
    {
        AudioSource.PlayClipAtPoint(shootSound, transform.position);
    }

    protected abstract void Move();
}
