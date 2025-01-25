using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public float score = 0;
    public float highscore;
    public int Adn = 0;
    public float lifes = 3;
    public float currentLevel;
    public float time = 0;

    
    private void Awake()
    {
        
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
           
            instance = this;
            
            DontDestroyOnLoad(gameObject);
        }
    }

}
