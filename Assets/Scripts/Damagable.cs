using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damagable : MonoBehaviour
{
    [field:SerializeField] public ObjectMaterial ObjectMaterial { get; private set; }
    [field:SerializeField] public float HealthPoints { get; private set; }
    public UnityEvent DamageEvent;
    public UnityEvent DestroyEvent;
    public void TryDamage(Weapon weapon)
    {
        if (!ObjectMaterial.CheckIfDamagable(weapon.DamageType)) return;
        HealthPoints -= weapon.DamagePoints;
        DamageEvent?.Invoke();
        if (HealthPoints <= 0)
        {
            DestroyEvent?.Invoke();
            gameObject.SetActive(false);
        }
    }

    
}
