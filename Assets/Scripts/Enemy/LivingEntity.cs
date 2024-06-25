using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour, IDamageable
{
    [SerializeField] private float startingHealth;
    protected float health;
    protected bool dead;

    public Action OnDeath;

    protected virtual void Start()
    {
        health = startingHealth;
    }

    public void TakeHit(float damage, RaycastHit hit)
    {
        health -= damage;
        if(health <= 0 && !dead)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        dead = true;
        if(OnDeath != null)
        {
            OnDeath();
        }
        Destroy(gameObject);
    }


}
