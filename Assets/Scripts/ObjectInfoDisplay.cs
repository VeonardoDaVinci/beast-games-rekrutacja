using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectInfoDisplay : MonoBehaviour
{
    [SerializeField] private Damagable objectInfoSource;
    [SerializeField] private TextMeshPro nameDisplay;
    [SerializeField] private TextMeshPro damageInfoDisplay;
    private void Start()
    {
        nameDisplay.text = objectInfoSource.ObjectMaterial.name;
        foreach (DamageType damageType in objectInfoSource.ObjectMaterial.DamagableBy)
        {
            damageInfoDisplay.text += "\n";
            damageInfoDisplay.text += damageType.ToString();
        }
    }
}
