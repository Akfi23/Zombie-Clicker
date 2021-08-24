using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using TMPro;


public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _recordsButton;
    [SerializeField] private Button _quittButton;

    [SerializeField] private List<int> _tempScores;

    [SerializeField] private TMP_Text _recordText;

    [SerializeField] private Image _panelTable;
    [SerializeField] private Image _panelTitle;



    public void StartGame() 
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    
    public void GetRecordList() 
    {
        _tempScores = PlayerPrefsExtra.GetList<int>("Scores");
        SortTable();
        _panelTable.gameObject.SetActive(true);
    }

    public void ClosePanel() 
    {
        _panelTable.gameObject.SetActive(false);
        _panelTitle.gameObject.SetActive(false);
    }

    public void OpenTitlePanel() 
    {
        _panelTitle.gameObject.SetActive(true);
    }

    private void SortTable() 
    {
        var sortedRecords = from score in _tempScores orderby score descending select score;

        for (int i = 0; i < 10; i++)
        {                   
            TMP_Text newRecordText = Instantiate(_recordText, _panelTable.transform);
            newRecordText.text = sortedRecords.ElementAt(i).ToString();                   
        }        
    }

}
