using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TextUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private ScoreCounter _counter;
    private Animator _animator;

    private void OnEnable()
    {
        _counter.ScoreChanged += OnScoreChanged;
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnDisable()
    {
        _counter.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int score) 
    {
        _scoreText.text = score.ToString();
        _animator.SetTrigger("Scored");
    }
}
