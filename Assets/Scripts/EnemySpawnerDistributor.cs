using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerDistributor : MonoBehaviour
{
    [SerializeField] private TimeSpan _spawnInterval = TimeSpan.FromSeconds(2);

    private readonly Queue<EnemySpawner> _spawners 
        = new Queue<EnemySpawner>();
    private DateTime _lastSpawnTime = DateTime.Now;
    private EnemySpawner _currentSpawner;


    private void FixedUpdate()
    {
        if (_currentSpawner == null)
            _currentSpawner = GetNextSpawner();

        if (_currentSpawner != null)
        {
            DateTime currentTime = DateTime.Now;

            TimeSpan offset = currentTime - _lastSpawnTime;

            if (offset >= _spawnInterval)
            {
                _currentSpawner.TrySpawnEnemy();
                _currentSpawner = null;

                _lastSpawnTime = currentTime;
            }

        }
    }

    private EnemySpawner GetNextSpawner()
    {
        if (_spawners.Count == 0)
            return null;

        EnemySpawner spawner = _spawners.Dequeue();
        _spawners.Enqueue(spawner);

        return spawner;
    }

    public void RegisterSpawner(EnemySpawner spawner)
    {
        _spawners.Enqueue(spawner);
    }
}
