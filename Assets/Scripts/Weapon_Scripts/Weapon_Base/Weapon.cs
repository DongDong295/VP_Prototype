using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] WeaponStats weaponStats;
    public Ability attack;
    public Ability abilityQ;
    public Ability abilityE;
    public Ability ultimate;

    protected string weaponName { get; private set; }

    public virtual void Awake()
    {
        InitializeWeapon();
    }

    public virtual void Update()
    {
        if (Input.GetMouseButton(0))
        {
            attack.Use();
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            abilityE.Use();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            abilityQ.Use();
        }
        if (Input.GetKeyDown(KeyCode.Space) && Character.ultPoint == 100)
        {
            ultimate.Use();
            Character.ultPoint = 0;
        }
    }

    void InitializeWeapon()
    {
        weaponName = weaponStats.weaponName;
    }
}
