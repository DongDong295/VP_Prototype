using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RussianTrait01 : Trait
{
    [SerializeField] Weapon weapon;
    [SerializeField] Ability replaceE;
    public override void ActiveTrait()
    {
        base.ActiveTrait();
        weapon.abilityE = replaceE;
        GameManager.Instance.StartWave();
    }
}
