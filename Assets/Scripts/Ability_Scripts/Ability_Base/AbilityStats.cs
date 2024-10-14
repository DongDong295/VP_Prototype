using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Ability")]
public class AbilityStats : ScriptableObject
{
    public string abilityName;
    public Type type;

    public float cooldown;
    public float damage;

    public enum Type
    {
        None,
        NormalAttack,
        Ability,
        Ultimate
    }
}
