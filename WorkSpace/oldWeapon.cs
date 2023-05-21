using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Transform _shootPoint;
    [SerializeField] float _weaponRange = 3f;
    [SerializeField] float _weaponDamage = 2;
    [SerializeField] Ammo _currentAmmo;
    //[SerializeField] ParticleSystem _shootEffectVFX;
    //[SerializeField] GameObject _hitImpactEffectVFX;

    public void AttackInteraction()
    {
        //PlayShootEffect();

        if (_currentAmmo.GetCurrentAmmo() > 0)
        {
            ProcessRaycast();
            _currentAmmo.ReduceCurrentAmmo();
        }
        else
            Debug.Log("no ammo");
    }

    //private void PlayShootEffect()
    //{
    //    _shootEffectVFX.Play();
    //}

    private void ProcessRaycast()
    {
        RaycastHit2D hit = Physics2D.Raycast(_shootPoint.position, _shootPoint.up);
        Debug.DrawRay(_shootPoint.transform.position, _shootPoint.up, Color.red); // delate

        if (hit.collider != null)
        {
            var target = hit.collider.TryGetComponent<ITakeDamage>(out ITakeDamage _healthControl);
            Debug.Log(hit.collider.name); //delate

            if (_healthControl != null)
                _healthControl.TakeDamage(_weaponDamage);
            //else
                //CreateHitImpact(hit);
        }
    }

    private void CreateHitImpact(RaycastHit2D hit)
    {
        //GameObject impact = Instantiate(_hitImpactEffectVFX, hit.point, Quaternion.LookRotation(hit.normal));
        //Destroy(this, 1f);

        //Particle System is trying to spawn on a mesh with zero surface area
    }
}
