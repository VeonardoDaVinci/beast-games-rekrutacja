using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : Weapon
{
    [SerializeField] private float attackRange = 1f;
    public override void Attack()
    {
        if (!CanAttack) return;
        base.Attack();
        //Debug.Log("Doing magic attack with a "+WeaponName +" for " + WeaponDamage + " damage.");
    }
}
