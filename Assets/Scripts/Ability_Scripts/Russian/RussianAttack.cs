using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class RussianAttack : Ability
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform shootPoint;

    bool canAttack;

    public override void Awake()
    {
        base.Awake();
        canAttack = true;
    }

    public override void Use()
    {
        if (canAttack) {
            var bullet = Instantiate(bulletPrefab, shootPoint.position, transform.rotation);
            bullet.GetComponent<BulletTest>().damage = damage;
            StartCoroutine(Cooldown()); 
        }
    }

    IEnumerator Cooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(cooldown);
        canAttack = true;
    }
    
    public IEnumerator IncreaseAttackTemp(float amount, float time)
    {
        var base_damage = damage;
        damage += amount;
        yield return new WaitForSeconds(time);
        damage = base_damage;
    }
}
