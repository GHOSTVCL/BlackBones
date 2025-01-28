using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DisableButtons : MonoBehaviour
{
    [SerializeField] private Button FireMinusButton;
    [SerializeField] private Button WaterMinusButton;
    [SerializeField] private Button ToxicMinusButton;
    [SerializeField] private Button DarkMinusButton;
    [SerializeField] private Button IceMinusButton;

    // Update is called once per frame
    void Update()
    {
       if(EvolutionManager.instance.FireEvolution == EvolutionManager.instance.savedFire)
        {
            FireMinusButton.interactable = false;
        }
        else
        {
            FireMinusButton.interactable = true;
        }
        if (EvolutionManager.instance.WaterEvolution == EvolutionManager.instance.savedWater)
        {
            WaterMinusButton.interactable = false;
        }
        else
        {
            WaterMinusButton.interactable = true;
        }
        if (EvolutionManager.instance.ToxicEvolution == EvolutionManager.instance.savedToxic)
        {
            ToxicMinusButton.interactable = false;
        }
        else
        {
            ToxicMinusButton.interactable = true;
        }
        if (EvolutionManager.instance.nightEvolution == EvolutionManager.instance.savedNight)
        {
            DarkMinusButton.interactable = false;
        }
        else
        {
            DarkMinusButton.interactable = true;
        }
        if (EvolutionManager.instance.IceEvolution == EvolutionManager.instance.savedIce)
        {
            IceMinusButton.interactable = false;
        }
        else
        {
            IceMinusButton.interactable = true;
        }
    }
}
