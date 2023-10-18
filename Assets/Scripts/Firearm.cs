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
        RaycastHit raycastHit;
        if(Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward, out raycastHit) )
        {
            Debug.Log(raycastHit.collider.name);
            if(HitObject = raycastHit.collider.GetComponent<Damagable>())
            {
                HitObject.TryDamage(this);
            }
        }
    }

    private void Reload()
    {
        Debug.Log("Reload");
        StartCoroutine(StartCooldown(reloadCooldown));
        projectilesLeft = magazineCapacity;
    }
}