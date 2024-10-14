using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RussianTrait03 : Trait
{
    [SerializeField] Weapon weapon;
    [SerializeField] Ability replaceUlt;
    public override void ActiveTrait()
    {
        base.ActiveTrait();
        weapon.ultimate = replaceUlt;
        GameManager.Instance.StartWave();
    }
}
