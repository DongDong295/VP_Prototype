using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Enemy")]
public class EnemyStats : ScriptableObject
{
    public string enemyName;
    public float health;
    public float speed;
    public float range;
}
