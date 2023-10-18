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
        RaycastHit raycastHit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out raycastHit, attackRange))
        {
            if (HitObject = raycastHit.collider.GetComponent<Damagable>())
            {
                HitObject.TryDamage(this);
            }
        }
    }
}
