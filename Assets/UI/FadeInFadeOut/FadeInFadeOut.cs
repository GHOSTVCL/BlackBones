using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FadeInFadeOut : MonoBehaviour
{
    [SerializeField]GameObject fadeOut;
    Animator animator;
    private int roomIndex;

    // Start is called before the first frame update
    void Start()
    {
        animator = fadeOut.GetComponent<Animator>();
        animator.Play("FadeIn");
        roomIndex = SaveRooms.instance.roomCount;
        Invoke("Deactivate", 1);
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "BornScreen")
        {
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
