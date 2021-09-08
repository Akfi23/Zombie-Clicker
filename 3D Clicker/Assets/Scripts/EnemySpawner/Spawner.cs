using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectPool
{
    private float _secondsPerSpawn;
    private float _currentTimer = 0;

    private void Start()
    {
        InitializeEnemies();
    }

    private void Update()
    {
        _currentTimer += Time.deltaTime;
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        if (_currentTimer >= _secondsPerSpawn)
        {
            _secondsPerSpawn = Random.Range(0.2f,1f);
            if (TryGetEnemy(out GameObject enemy))
            {
                _currentTimer = 0;

                SetEnemyPos(enemy);
            }
        }
    }

    private void SetEnemyPos(GameObject enemy)
    {
        float posX = Random.Range(-6f,7f);
        float posZ = Random.Range(4f,40f);

        enemy.SetActive(true);
        enemy.transform.position = new Vector3(posX,0, posZ);
    }
}
