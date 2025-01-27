using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisabledContinue : MonoBehaviour
{
    Button buttonContinue;

    private void Start()
    {
        buttonContinue = GetComponent<Button>();
    }
    private void Update()
    {
        if(SaveRooms.instance.intesitysLvl1.Count == 0)
        {
            buttonContinue.interactable = false;
        }
        else
        {
            buttonContinue.interactable = true;
        }
    }
}
