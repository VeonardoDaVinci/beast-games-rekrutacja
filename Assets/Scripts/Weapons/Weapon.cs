using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Weapon : MonoBehaviour
{
    [field: SerializeField] public string WeaponName { get; protected set; }
    [field: SerializeField] public float DamagePoints { get; protected set; }
    [field: SerializeField] public float AttackCooldown { get; protected set; } = 0;
    [field: SerializeField] public DamageType DamageType { get; protected set; }
    [field: SerializeField] public Damagable HitObject { get; protected set; }
    public UnityEvent AttackEvent;
    protected bool CanAttack { get; set; } = true;

    public virtual void Attack()
    {
        AttackEvent?.Invoke();
        StartCoroutine(StartCooldown(AttackCooldown));
    }
    public Weapon Equip()
    {
        CanAttack = true;
        gameObject.SetActive(true);
        return this;
    }
    public Weapon Unequip()
    {
        CanAttack = false;
        gameObject.SetActive(false);
        return this;
    }
    public IEnumerator StartCooldown(float cooldownTime)
    {
        CanAttack = false;
        yield return new WaitForSeconds(cooldownTime);
        CanAttack = true;
    }
}
