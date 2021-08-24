using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private static GameManager _gameManager;
    public static GameManager GameLogic
    {
        get
        {
            if (_gameManager == null)
            {
                _gameManager = FindObjectOfType<GameManager>();
            }
            return _gameManager;
        }
    }

    public event UnityAction GameEnded;

    [SerializeField] ObjectPool _pool;
    private bool _isFull;

    private void Awake()
    {
        //DontDestroyOnLoad(this);
    }

    private void Start()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (Time.timeScale == 1) 
        {
            CheckGameStatus();
        }
    }

    private void CheckGameStatus() 
    {
        _isFull = _pool.CountEnemies();

        if (_isFull)
        {
            GameEnded?.Invoke();
            Time.timeScale = 0;
        }
    }
}
