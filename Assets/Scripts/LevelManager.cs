using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private TextMeshProUGUI adnText;
    void Update()
    {
        scoreText.text = GameManager.instance.score.ToString() + " pts";
        timeText.text = GameManager.instance.time.ToString();
        livesText.text = "X" +GameManager.instance.lifes.ToString();
        adnText.text = "X" + GameManager.instance.Adn.ToString();
             
    }
}
