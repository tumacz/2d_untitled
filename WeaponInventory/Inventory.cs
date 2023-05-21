using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    // 0 = melee, 1 = primary, 2 = secondary
    [SerializeField] private Weapon[] weapons;
    [SerializeField] private Weapon defaultWeapon = null;

    private WeaponShooting _weaponShooting;
    //private PlayerHUD _hud;
 
    private void Start()
    {
        GetReferences();
        InitVariables();
    }

    public void AddItem(Weapon newItem)
    {
        int newItemIndex = (int)newItem._weaponHolder;
        if (weapons[newItemIndex] != null)
            RemoveItem(newItemIndex);

        weapons[newItemIndex] = newItem;
        _weaponShooting.InitAmmo((int)newItem._weaponHolder, newItem);
    }



    public void RemoveItem(int index)
    {
        weapons[index] = null;
    }

    public Weapon GetItem(int index)
    {
        return weapons[index];
    }

    private void GetReferences()
    {
        _weaponShooting = GetComponent<WeaponShooting>();
    }

    private void InitVariables()
    {
        weapons = new Weapon[3];
    }
}
