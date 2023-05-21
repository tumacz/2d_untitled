using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShooting : MonoBehaviour
{
    private float _lastShootTime = 0f;

    [SerializeField] private int _primaryCurrentAmmo;
    [SerializeField] private int _primaryCurrentMagazine;

    [SerializeField] private int _secondaryCurrentAmmo;
    [SerializeField] private int _secondaryCurrentMagazine;

    [SerializeField] private Transform _shootPoint;

    [SerializeField] private bool _primaryMagazineEmpty = false;
    [SerializeField] private bool _secondaryMagazineEmpty = false;

    private bool _canShoot = true;


    private Inventory _inventory;
    private EquipmentManager _manager;

    private void Start()
    {
        GetReferences();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    private void RaycastShoot(Weapon currentWeapon)
    {
        float weaponRange = currentWeapon._range;
        Instantiate(currentWeapon._particleSystemPrefab, _manager._currentParticleSystem);
        RaycastHit2D hit = Physics2D.Raycast(_shootPoint.position, _shootPoint.up, weaponRange);
        Debug.DrawRay(_shootPoint.transform.position, _shootPoint.up * weaponRange, Color.red, 0.2f); // delate

        if (hit.collider != null)
        {
            var target = hit.collider.TryGetComponent<ITakeDamage>(out ITakeDamage _healthControl);
            Debug.Log(hit.collider.name); //delate

            //if (_healthControl != null)
            //_healthControl.TakeDamage(_weaponDamage);
            //else
            //CreateHitImpact(hit);
        }
    }

    private void Shoot()
    {
        CheckCanShoot(_manager._currentlyEquipedWeapon);
        if (_canShoot)
        {
            Weapon currentWeapon = _inventory.GetItem(_manager._currentlyEquipedWeapon);

            if (Time.time > _lastShootTime + currentWeapon._fireRate)
            {
                Debug.Log("bam");//a place for audio?
                _lastShootTime = Time.time;

                RaycastShoot(currentWeapon);
                UseAmmo((int)currentWeapon._weaponHolder, 1, 0);
            }
        }
        else
            Debug.Log("no ammo");
        
    }

    private void CheckCanShoot(int slot)
    {
        //primary
        if(slot == 1)
        {
            if (_primaryMagazineEmpty)
                _canShoot = false;
            else
                _canShoot = true;
        }

        if (slot == 2)
        {
            if (_secondaryMagazineEmpty)
                _canShoot = false;
            else
                _canShoot = true;
        }
    }

    public void InitAmmo(int slot, Weapon weapon)
    {
        //primary
        if(slot == 1)
        {
            _primaryCurrentAmmo = weapon._magazineSize;
            _primaryCurrentMagazine = weapon._magazineSize;
        }
        //secondary
        if(slot ==2)
        {
            _secondaryCurrentAmmo = weapon._magazineSize;
            _secondaryCurrentMagazine = weapon._magazineSize;
        }
    }

    private void UseAmmo(int slot, int currentAmmoUsed, int currentStoredAmmoUsed)
    {
        //primary
        if(slot == 1) //primary (int)currentWeapon._weaponType
        {
            if (_primaryCurrentAmmo <= 0)
            {   
                _primaryMagazineEmpty = true;
                CheckCanShoot(_manager._currentlyEquipedWeapon);
            }
            else
            {
                _primaryCurrentAmmo -= currentAmmoUsed;
                _primaryCurrentMagazine -= currentStoredAmmoUsed;
            }

        }
        //secondary
        if (slot == 2) //secondary (int)currentWeapon._weaponType
        {
            if (_secondaryCurrentAmmo <= 0)
            {
                _secondaryMagazineEmpty = true;
                CheckCanShoot(_manager._currentlyEquipedWeapon);
            }
            else
            {
                _secondaryCurrentAmmo -= currentAmmoUsed;
                _secondaryCurrentMagazine -= currentStoredAmmoUsed;
            }
        }
    }

    private void GetReferences()
    {
        _inventory = GetComponent<Inventory>();
        _manager = GetComponent<EquipmentManager>();
    }
}
