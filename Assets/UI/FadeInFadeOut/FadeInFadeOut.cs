using System.Collections;
using System.Collections.Generic;
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
    }

    private void Update()
    {
        if(roomIndex != SaveRooms.instance.roomCount)
        {
            animator.Play("FadeOut");
            Invoke("FadeIn", 1);
            roomIndex = SaveRooms.instance.roomCount;
        }
    }

    public void FadeIn()
    {
        animator.Play("FadeIn");
    }
    public void FadeOut()
    {
        animator.Play("FadeOut");
    }
}
