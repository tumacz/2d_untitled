using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    private PlayerHUD _hud;
    private Inventory _inventroy;
    public int _currentlyEquipedWeapon = 1;
    public Transform _currentParticleSystem = null;
    private GameObject _currentWeaponObject = null;

    [SerializeField] private Transform _weaponHolder = null;
    [SerializeField] private Weapon _deafoultWeaponObject = null;

    private void Start()
    {
        GetReferences();
        InitVariables();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && _currentlyEquipedWeapon != 0)
        {
            UnequipWeapon();
            EquipWeapon(_inventroy.GetItem(0));
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && _currentlyEquipedWeapon != 1 && _inventroy.GetItem(1) != null)
        {
            UnequipWeapon();
            EquipWeapon(_inventroy.GetItem(1));
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && _currentlyEquipedWeapon != 2 && _inventroy.GetItem(2) != null)
        {
            UnequipWeapon();
            EquipWeapon(_inventroy.GetItem(2));
        }
    }

    private void EquipWeapon(Weapon weapon)
    {
        _currentlyEquipedWeapon = (int)weapon._weaponHolder;
        _currentWeaponObject = Instantiate(weapon._prefab, _weaponHolder);
        _currentParticleSystem = _currentWeaponObject.transform.GetChild(0); //!Get transform of first nest in gameObject prefab
        _hud.UpdateWeaponUI(weapon);
    }

    private void UnequipWeapon()
    {
        Destroy(_currentWeaponObject);
    }

    private void InitVariables()
    {
        _inventroy.AddItem(_deafoultWeaponObject);
        EquipWeapon(_inventroy.GetItem(0));
    }

    private void GetReferences()
    {
        _hud = GetComponent<PlayerHUD>();
        _inventroy = GetComponent<Inventory>();
    }
}