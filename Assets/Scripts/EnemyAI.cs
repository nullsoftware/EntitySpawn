using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// simple enemy AI walking in random paths
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyAI : MonoBehaviour
{
    [SerializeField] private int _flyRadius = 5;
    [SerializeField] private int _speed = 5;

    private Vector2 _spawnPoint;
    private Vector2 _endpoint;
    private Rigidbody2D _rigidbody;

    private int MinRandomDistance => -(_flyRadius);
    private int MaxRandomDistance => _flyRadius;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spawnPoint = _rigidbody.position;

        GenerateRandomPath();
    }

    private void Update()
    {
        _rigidbody.position += (_endpoint - _rigidbody.position).normalized * _speed * Time.deltaTime;

        if (Vector2.Distance(_rigidbody.position, _endpoint) <= 1)
        {
            GenerateRandomPath();
        }
    }

    private void GenerateRandomPath()
    {
        Vector2 rand = new Vector2(
            Random.Range(MinRandomDistance, MaxRandomDistance), 
            Random.Range(MinRandomDistance, MaxRandomDistance));

        _endpoint = _rigidbody.position + rand;

        if (Vector2.Distance(_spawnPoint, _endpoint) >= _flyRadius)
        {
            _endpoint = _spawnPoint + rand;
        }
        
    }
}
