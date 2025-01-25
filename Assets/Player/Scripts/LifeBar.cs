using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    [SerializeField] public Image lifeBar;
    private player p;
    private void Awake()
    {
        p = GetComponent<player>();
    }


    void Update()
    {
        if (p.resetlife)
        {
            lifeBar.fillAmount = 1;
        }
        else
        {
            lifeBar.fillAmount = p.actuallife / p.maxlife;
        }
        
        
    }
}
