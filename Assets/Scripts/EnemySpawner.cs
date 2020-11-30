using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemySpawnerDistributor _manager;
    [SerializeField] private GameObject _template;
    [SerializeField] private int _maxObjectsCount = 5;

    private readonly List<GameObject> _pool = new List<GameObject>();


    private void Start()
    {
        _manager.RegisterSpawner(this);
    }

    public bool TrySpawnEnemy()
    {
        if (_pool.Count >= _maxObjectsCount)
            return false;

        GameObject created = Instantiate(_template);

        created.transform.position = transform.position;

        _pool.Add(created);

        Debug.Log("Enemy spawned.");

        return true;
    }
}
