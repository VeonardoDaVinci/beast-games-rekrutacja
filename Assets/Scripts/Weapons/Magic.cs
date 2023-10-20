using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Magic : Weapon
{
    [SerializeField] private float attackRange = 1f;
    [SerializeField] private float attackDelay = 0.5f;
    private UnityEvent DeleyEvent = new();
    private void Start()
    {
        DeleyEvent.AddListener(DetectDamageble);
    }
    public override void Attack()
    {
        if (!CanAttack) return;
        base.Attack();
        StartCoroutine(AttackDelay());
    }
    private void DetectDamageble()
    {
        RaycastHit raycastHit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out raycastHit, attackRange))
        {
            if (HitObject = raycastHit.collider.GetComponent<Damagable>())
            {
                HitObject.TryDamage(this);
            }
        }
    }
    private IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(attackDelay);
        DeleyEvent?.Invoke();
    }
}
