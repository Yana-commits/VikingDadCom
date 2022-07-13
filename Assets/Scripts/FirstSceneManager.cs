using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FirstSceneManager : MonoBehaviour
{
    [SerializeField] private Button playBt;
    [SerializeField] private Button exitBt;


    void Start()
    {
        playBt.onClick.AddListener(LoadScene);
        exitBt.onClick.AddListener(Exit);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    private void Exit()
    {
        Application.Quit();
    }

    private void OnDisable()
    {
        playBt.onClick.RemoveListener(LoadScene);
        exitBt.onClick.RemoveListener(Exit);
    }
}
