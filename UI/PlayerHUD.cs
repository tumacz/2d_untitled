using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] private ProgressBar _progressBar;
    [SerializeField] private WeaponUI _weaponUI;

    public void UpdateHealth(int currentHealth, int maxHealth)
    {
        _progressBar.SetValues(currentHealth, maxHealth);
    }

    public void UpdateWeaponUI(Weapon newWeapon)
    {
        _weaponUI.UpdateInfo(newWeapon._sprite, newWeapon._magazineSize, newWeapon._magazineCount);
    }
}
