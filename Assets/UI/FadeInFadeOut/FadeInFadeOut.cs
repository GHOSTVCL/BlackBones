using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FadeInFadeOut : MonoBehaviour
{
    [SerializeField]GameObject fadeOut;
    Animator animator;
    private int levelIndex;

    // Start is called before the first frame update
    void Start()
    {
        animator = fadeOut.GetComponent<Animator>();
        levelIndex = SaveRooms.instance.levelCount;
        Invoke("Deactivate", 1);
    }

    private void Update()
    {
        if(levelIndex != SaveRooms.instance.levelCount)
        {
            levelIndex = SaveRooms.instance.levelCount;
            FadeOut();
        }
    }

    public void FadeIn()
    {
        fadeOut.SetActive(true);
        animator.Play("FadeIn");
    }
    public void FadeOut()
    {
        fadeOut.SetActive(true);
        animator.Play("FadeOut");
    }
    public void Deactivate()
    {
        fadeOut.SetActive(false);
    }
}
