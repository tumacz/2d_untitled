using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Weapon", menuName = "Items/Weapon")]
public class Weapon : Item
{
    public GameObject _prefab;
    public ParticleSystem _particleSystemPrefab;
    public int _magazineSize;
    public int _magazineCount;
    public float _range;
    public float _fireRate;
    public WeaponType _weaponType;
    public WeaponHolder _weaponHolder;
}

public enum WeaponType { Melee, Pistol, Rifle, Shotgun}

public enum WeaponHolder { Melee, Primary, Secondary}
