using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreCounter : MonoBehaviour
{
    private static ScoreCounter _scoreManager=null;
    public static ScoreCounter ScoreManager
    {
        get
        {
            if (_scoreManager == null)
            {
                _scoreManager = FindObjectOfType<ScoreCounter>();
            }
            return _scoreManager;
        }
    }

    [SerializeField] private int _lastScore;
    [SerializeField] private List<int> _scores;

    public event UnityAction<int> ScoreChanged;
    public event UnityAction GetHigherScore;
    private void Awake()
    {        
        //DontDestroyOnLoad(this);
    }

    private void Start()
    {
        GetPrefList();
    }

    private void OnEnable()
    {
        Enemy.Killed += OnEnemyKilled;
        GameManager.GameLogic.GameEnded += AddScoreToList;
    }

    private void OnDisable()
    {
        Enemy.Killed -= OnEnemyKilled;
        //GameManager.GameLogic.GameEnded -= AddScoreToList;
    }

    private void OnEnemyKilled() 
    {
        _lastScore ++;
        ScoreChanged?.Invoke(_lastScore);

        if (_lastScore > 30) 
        {
            GetHigherScore?.Invoke();
        }
    }
    
    private void AddScoreToList() 
    {
        int score = _lastScore;
        _scores.Add(score);
        PlayerPrefsExtra.SetList("Scores",_scores);
    }

    public List<int> GetPrefList()
    {
        _scores = PlayerPrefsExtra.GetList<int>("Scores", new List<int>());
        return _scores;
    }
}
