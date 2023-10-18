using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : Weapon
{
    [SerializeField] private float attackRange = 1f;
    public override void Attack()
    {
        if (!CanAttack) return;
        base.Attack();
        //Debug.Log("Doing melee attack with a " + WeaponName +" for " + WeaponDamage + " damage.");
    }
}
