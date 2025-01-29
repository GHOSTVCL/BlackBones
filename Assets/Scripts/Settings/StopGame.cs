using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class StopGame : MonoBehaviour
{

    public void PauseWorld()
    {
        Time.timeScale = 0.0f;
    }

    public void ReturnTimeWorld()
    {
        Time.timeScale = 1.0f;
    }
   

}
