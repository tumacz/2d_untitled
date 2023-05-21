using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthControl : MonoBehaviour, ITakeDamage
{
    [SerializeField] float _health = 10;
    private EnemyController _enemy;

    private void Start()
    {
        _enemy = GetComponentInParent<EnemyController>();
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("ITakeDAmage");
        _health -= damage;
        if(_health <= 0)
        {
            _enemy.Die();
        }
    }

}
