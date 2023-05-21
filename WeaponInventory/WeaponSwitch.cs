using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponSwitch : MonoBehaviour
{
    private PlayerInput _playerInput;
    private InputAction _switchUpWeapon;
    private InputAction _switchDownWeapon;
    //private WeaponControl _weaponControl;
    private Inventory _inventory;
    //private Weapon _activeWeapon = null;


    //[SerializeField] private int _selectedWeapon = 1;
    //[SerializeField] private List<WeaponSlot> weaponList;

    //void Awake()
    //{
    //    GetReferences();
    //}

    //void Start()
    //{
    //    SelectWeapon();
    //    SwitchWeapon(_selectedWeapon);
    //}

//    private void OnEnable()
//    {
//        _switchUpWeapon.performed += _ => ChangeWeaponUp();
//        _switchUpWeapon.canceled += _ => ChangeWeaponUp();

//        _switchDownWeapon.performed += _ => ChangeWeaponDown();
//        _switchDownWeapon.canceled += _ => ChangeWeaponDown();
//    }

//    private void OnDisable()
//    {
//        _switchUpWeapon.performed -= _ => ChangeWeaponUp();
//        _switchUpWeapon.canceled -= _ => ChangeWeaponUp();

//        _switchDownWeapon.performed -= _ => ChangeWeaponDown();
//        _switchDownWeapon.canceled -= _ => ChangeWeaponDown();
//    }

//    private void SelectWeapon()
//    {
//        int weaponSlot = 0;

//        foreach (WeaponSlot weapon in weaponList)
//        {
//            if (weaponSlot == _selectedWeapon)
//                weapon.gameObject.SetActive(true);
//            else
//                weapon.gameObject.SetActive(false);

//            weaponSlot++;
//        }
//    }

//    private void ChangeWeaponUp()
//    {
//        Debug.Log("changeweaponUp");

        
//        if(_selectedWeapon <= 0)
//            _selectedWeapon = weaponList.Count - 1;
//        else
//            _selectedWeapon--;

//        SwitchWeapon(_selectedWeapon);
//    }

//    private void ChangeWeaponDown()
//    {
//        Debug.Log("changeweaponDown");

//        if (_selectedWeapon >= weaponList.Count -1)
//            _selectedWeapon = 0;
//        else
//            _selectedWeapon++;

//        SwitchWeapon(_selectedWeapon);
//    }

//    private void SwitchWeapon(int selectedWeapon)
//    {
//        foreach (WeaponSlot weapon in weaponList)
//        {
//            weapon.gameObject.SetActive(false);
//        }

//        weaponList[selectedWeapon].gameObject.SetActive(true);

//        var myWeapon = weaponList[selectedWeapon];
//        //_activeWeapon = myWeapon.GetComponent<Weapon>();
//        //_weaponControl.SetActiveWeapon(_activeWeapon);
//    }

//    private void GetReferences()
//    {
//        _playerInput = FindObjectOfType<PlayerInput>();
//        _switchUpWeapon = _playerInput.actions["SwitchUpWeapon"];
//        _switchDownWeapon = _playerInput.actions["SwitchDownWeapon"];
//        //_weaponControl = GetComponent<WeaponControl>();
//        _inventory = GetComponent<Inventory>();
//    }
}
