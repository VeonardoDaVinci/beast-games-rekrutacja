using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{
    public InputAction LeftMouseButton;
    public InputAction RightMouseButton;

    [SerializeField] private List<Weapon> weapons;
    private Weapon currentWeapon;
    private int currentWeaponIndex;
    private void OnEnable()
    {
        RightMouseButton.Enable();
        LeftMouseButton.Enable();
    }

    private void OnDisable()
    {
        RightMouseButton.Disable();
        LeftMouseButton.Disable();
    }
    private void Start()
    {
        LeftMouseButton.performed += OnLeftButtonClicked;
        RightMouseButton.performed += OnRightButtonClicked;
        UnequipAllWeapons();
        EquipWeapon(0);
    }

    private void OnRightButtonClicked(InputAction.CallbackContext callbackContext)
    {
        UnequipAllWeapons();
        EquipWeapon(currentWeaponIndex + 1);
    }

    private void OnLeftButtonClicked(InputAction.CallbackContext callbackContext)
    {
        currentWeapon.Attack();
    }
    private void UnequipAllWeapons()
    {
        foreach (Weapon weapon in weapons)
        {
            weapon.Unequip();
        }
    }
    private void EquipWeapon(int weaponIndex)
    {
        if(weaponIndex != 0)
        {
            weaponIndex %= weapons.Count;
        }
        currentWeapon = weapons[weaponIndex].Equip();
        currentWeaponIndex = weaponIndex;
    }

    private void EquipWeapon(string weaponName)
    {
        foreach (Weapon weapon in weapons)
        {
            if (weapon.WeaponName == weaponName)
            {
                weapon.Equip();
                currentWeaponIndex = weapons.IndexOf(weapon);
                return;
            }
        }
    }
}

