using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    [SerializeField] private AudioClip Sound;
    private AudioSource audioSource;
    public float score = 0;
    public int Adn = 0;
    public int EnemyCount = 0;
    public float lifes = 3;
    public float currentLevel;
    public float time = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        audioSource = GetComponent<AudioSource>();
        
    }
    private void Update()
    {
        if(EnemyCount == 3)
        {
            audioSource.PlayOneShot(Sound);
            Adn++;
            EnemyCount = 0;
        }
    }



}
