using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisabledContinue : MonoBehaviour
{
    Button buttonContinue;

    private void Update()
    {
        if(SaveRooms.instance.intesitysLvl1.Count == 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
