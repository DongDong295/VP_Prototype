using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RussianTrait02 : Trait
{
    [SerializeField] Weapon weapon;
    [SerializeField] Ability replaceQ;
    public override void ActiveTrait()
    {
        base.ActiveTrait();
        weapon.abilityQ = replaceQ;
        GameManager.Instance.StartWave();
    }
}
