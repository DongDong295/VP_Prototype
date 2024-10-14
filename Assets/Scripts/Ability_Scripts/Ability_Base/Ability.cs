using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    [SerializeField] AbilityStats stats;
    public float cooldown;
    public float damage;

    public virtual void Awake()
    {
        InitializeSkill();
    }

    public virtual void Use() { }

    void InitializeSkill()
    {
        cooldown = stats.cooldown;
        damage = stats.damage;
    }
}
