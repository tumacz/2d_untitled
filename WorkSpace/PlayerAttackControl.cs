using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttackControl : MonoBehaviour
{
    private PlayerInput _playerInput;
    private InputAction _fireAction;
    //private WeaponControl _weaponControl;

    void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _fireAction = _playerInput.actions["Fire"];
        //_weaponControl = GetComponentInChildren<WeaponControl>();
    }

    private void OnEnable()
    {
        _fireAction.performed += _ => StartShoot();
        _fireAction.canceled += _ => CancelShoot();
    }

    private void OnDisable()
    {
        _fireAction.performed -= _ => StartShoot();
        _fireAction.canceled -= _ => CancelShoot();
    }
    private void StartShoot()
    {
        //_weaponControl.OnAttack();
    }

    private void CancelShoot()
    {
        return;
    }
}
