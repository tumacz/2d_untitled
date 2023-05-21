using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Transform _target; //redo
    [SerializeField] private float _chaseRange = 5f;
    private float _distanceToTarget = Mathf.Infinity;

    private NavMeshAgent navMeshAgent;
    [SerializeField] private float _rotoationSpeed = 2f;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        navMeshAgent.updateRotation = false; //navMeshAgent for 2D doesn't work that way: Look to FaceToTarget()
        navMeshAgent.updateUpAxis = false; //navMeshAgent for 2D has its hight, that prevents from change transform.position.z value
    }

    private void Update()
    {   
        //add some states?
        if(_target != null)
        _distanceToTarget = Vector2.Distance(_target.position, transform.position);

        if (_distanceToTarget <= _chaseRange)
        {
            navMeshAgent.SetDestination(_target.position);
            FaceToTarget();
        }
    }

    private void FaceToTarget()
    {
        Vector2 direction = (_target.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, _rotoationSpeed *Time.deltaTime);
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }
}


//private void OnCollisionEnter2D(Collision2D other)
//{
//    Debug.Log("destroyed");
//}


//private void OnTriggerEnter2D(Collider2D collision)
//{ 
//    Debug.Log("provoked");
//}