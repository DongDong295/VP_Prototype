using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trait : MonoBehaviour
{
    [SerializeField] TraitStats traitStats;

    public string traitName;
    public string traitDescription;

    private void Awake()
    {
        InitializeTrait();
    }

    private void Start()
    {
        
    }

    public virtual void ActiveTrait(){}

    void InitializeTrait()
    {
        traitName = traitStats.traitName;
        traitDescription = traitStats.description;
    }
}
