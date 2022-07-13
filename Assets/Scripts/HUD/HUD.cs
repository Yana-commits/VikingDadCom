using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI score;

    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameOverPanel gameOverPanel;

    public void Sethealth(int health)
    {
        slider.value = health;
    }

    public void Setmaxhealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetScore(int value)
    {
        score.text = "Score : " + value.ToString();
    }

    public void SetGameOverPanel(int value)
    {
        gamePanel.SetActive(false);
        gameOverPanel.gameObject.SetActive(true);
        gameOverPanel.SetScore(value);
    }
}
