using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firearm : Weapon
{
    [SerializeField] private int magazineCapacity = 0;
    [SerializeField] private float reloadCooldown = 0f;
    private int projectilesLeft = 0;
    public override void Attack()
    {
        if (!CanAttack) return;
        if(projectilesLeft == 0)
        {
            Reload();
            return;
        }
        projectilesLeft--;
        base.Attack();
        //Debug.Log("Fiering weapon");
    }

    private void Reload()
    {
        Debug.Log("Reload");
        StartCoroutine(StartCooldown(reloadCooldown));
        projectilesLeft = magazineCapacity;
    }
}
