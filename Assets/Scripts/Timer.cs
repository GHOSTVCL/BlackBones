using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;

    
    private int minutes, seconds, cents;

    // Update is called once per frame
    private void Update()
    {
        GameManager.instance.time += Time.deltaTime;
        minutes =(int)GameManager.instance.time / 60;
        seconds =(int)GameManager.instance.time - minutes * 60;
        cents = (int)((GameManager.instance.time - (int)GameManager.instance.time) * 100);

        timerText.text = string.Format("{0}:{1:00}:{2:00}", minutes, seconds, cents);
    }
}
