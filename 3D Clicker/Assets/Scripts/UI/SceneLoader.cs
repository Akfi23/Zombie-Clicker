using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Button _restartButton;

    private void OnEnable()
    {
        GameManager.GameLogic.GameEnded += OnGameEnded;
    }

    private void OnDisable()
    {
        //GameManager.GameLogic.GameEnded += OnGameEnded;
    }

    private void Awake()
    {
        _restartButton.gameObject.SetActive(false);
    }

    public void LoadMainScene() 
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void RestartScene() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    private void OnGameEnded() 
    {
        _restartButton.gameObject.SetActive(true);
    }

}
