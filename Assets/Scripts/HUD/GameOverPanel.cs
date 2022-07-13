using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private Button restartBt;
    [SerializeField] private Button exitBt;
    [SerializeField] private TextMeshProUGUI score;
    void Start()
    {
        restartBt.onClick.AddListener(LoadScene);
        exitBt.onClick.AddListener(Exit);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Exit()
    {
        Application.Quit();
    }
    public void SetScore(int value)
    {
        score.text = "Score : " + value.ToString();
    }

    private void OnDisable()
    {
        restartBt.onClick.RemoveListener(LoadScene);
        exitBt.onClick.RemoveListener(Exit);
    }
}
