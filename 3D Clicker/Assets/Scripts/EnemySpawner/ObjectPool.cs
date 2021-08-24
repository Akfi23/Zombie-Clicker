using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private List<GameObject> _enemies = new List<GameObject>();
    [SerializeField] private int _capacityOfPool;
    [SerializeField] private GameObject _poolContainer;

    [SerializeField] private GameObject[] _enemiesPrefabs;


    protected void InitializeEnemies()
    {
        for (int i = 0; i < _capacityOfPool; i++)
        {
            GameObject newEnemy = Instantiate(_enemiesPrefabs[Random.Range(0, _enemiesPrefabs.Length)], _poolContainer.transform);
            newEnemy.SetActive(false);
            _enemies.Add(newEnemy);
        }
    }

    protected bool TryGetEnemy(out GameObject result)
    {
        result = _enemies.First(enemy => enemy.activeSelf == false);
        return result != null;
    }

    public bool CountEnemies() 
    {
        int i = 0;

        foreach (var enemy in _enemies)
        {
            if (enemy.activeSelf == true) 
            {
                i++;
            }
        }

        Debug.Log($"{i}  / {_enemies.Count}");

        if (i == _enemies.Count) 
        {
            return true;
        }

        return false;
    }
}
