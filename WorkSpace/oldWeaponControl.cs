using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponControl : MonoBehaviour
{
    [SerializeField] private Weapon _activeWeapon;

    public void SetActiveWeapon(Weapon newWeapon)
    {
        _activeWeapon = newWeapon;
    }

    public void OnAttack()
    {
        Debug.Log("weaponcontrollwork");
        _activeWeapon.AttackInteraction();     
    }
}
