using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] protected string projectileName;
    [SerializeField] protected float projectileSpeed;
    [SerializeField] protected int projectileAmount;
    [SerializeField] protected float damage;

    protected abstract void Move();
}
