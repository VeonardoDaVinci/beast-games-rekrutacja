using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectMaterial", menuName = "ScriptableObjects/ObjectMaterial", order = 1)]
public class ObjectMaterial : ScriptableObject
{
    public List<DamageType> DamagableBy;
    public bool CheckIfDamagable(DamageType type)
    {
        return DamagableBy.Contains(type);
    }
}
