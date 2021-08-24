using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Transform _transform;
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private Vector3 _walkPoint;
    [SerializeField] private float _walkPointRange;
    private bool _walkPointSet;

    private void OnEnable()
    {
        ScoreCounter.ScoreManager.GetHigherScore += OnSpeedBoost;
    }

    private void OnDisable()
    {
        //ScoreCounter.ScoreManager.GetHigherScore -= OnSpeedBoost;
    }

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = 3.5f;
    }

    private void Update()
    {
        Patroling();
    }

    private void Patroling() 
    {
        if (!_walkPointSet) 
        {
            FindWalkPoint();
        }

        if (_walkPointSet) 
        {
            _agent.SetDestination(_walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - _walkPoint;

        if (distanceToWalkPoint.magnitude < 1f) 
        {
            _walkPointSet = false;
        }
    }

    private void FindWalkPoint() 
    {
        float randomX = Random.Range(-_walkPointRange, _walkPointRange);
        float randomZ = Random.Range(-_walkPointRange, _walkPointRange);

        float walkPointX = transform.position.x + randomX;
        float walkPointZ = transform.position.z + randomZ;

        _walkPoint = new Vector3(walkPointX, transform.position.y ,walkPointZ);


        if (Physics.Raycast(_walkPoint, -transform.up, 2f, _whatIsGround)) 
        {
            _walkPointSet = true;
        }
    }

    private void OnSpeedBoost() 
    {
        _agent.speed = 10f;
    }
}
