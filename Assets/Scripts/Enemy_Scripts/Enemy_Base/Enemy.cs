using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] EnemyStats enemyStats;
    public float health;
    public float speed;
    public float range;

    private void Awake()
    {
        InitializeEnemy();
    }

    public virtual void Start()
    {
        
    }

    public virtual void Update()
    {
        
    }

    public void InitializeEnemy()
    {
        range = enemyStats.range;
        speed = enemyStats.speed; 
        health = enemyStats.health;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        Character.IncreaseUlt(damage);
        if (health <= 0)
            Destroy(gameObject);
    }
}
