using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damagable : MonoBehaviour
{
    [field:SerializeField] public ObjectMaterial ObjectMaterial { get; private set; }
    [field:SerializeField] public float HealthPoints { get; private set; }
    public UnityEvent DestroyEvent;

    public void TryDamage(Weapon weapon)
    {
        if(!ObjectMaterial.CheckIfDamagable(weapon.DamageType)) return;
        Debug.Log(name);
        HealthPoints -= weapon.DamagePoints;
        if(HealthPoints <= 0)
        {
            DestroyEvent.Invoke();
            Destroy(this.gameObject);
        }
    }
}
