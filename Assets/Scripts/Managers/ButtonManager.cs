using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameOverManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void GameStart()
    {
        SceneManager.LoadScene(1);
    }
    public void TitleMenu()
    {
        GameManager.instance.lifes = 3;
        GameManager.instance.time = 0;
        GameManager.instance.score = 0;
        GameManager.instance.Adn = 0;
        SceneManager.LoadScene("TitleScreen");
    }
    public void Rebirth()
    {
        GameManager.instance.lifes = 3;
        GameManager.instance.time = 0;
        GameManager.instance.score = 0;
        GameManager.instance.Adn = 0;
        SceneManager.LoadScene("BornScreen");
    }
}
