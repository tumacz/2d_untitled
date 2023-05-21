using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _magzainesText;
    [SerializeField] private TextMeshProUGUI _ammoText;

    public void UpdateInfo(Sprite weaponIcon, int magazinesize, int currentAmmo)
    {
        _icon.sprite = weaponIcon;
        _magzainesText.text = magazinesize.ToString();
        _ammoText.text = currentAmmo.ToString();
    }

}
