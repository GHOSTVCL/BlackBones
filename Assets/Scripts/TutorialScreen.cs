using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TutorialScreen : MonoBehaviour
{
    public Canvas playerUI;
    public Canvas Controlls;
    public Canvas EvolveManager;
    public Canvas Ambient;
   public void Start()
    {
        playerUI.gameObject.SetActive(true);
        Ambient.gameObject.SetActive(false);
        EvolveManager.gameObject.SetActive(false);
        Controlls.gameObject.SetActive(false);
    }
    public void playerUIToAmbient()
    {
        playerUI.gameObject.SetActive(false);
        Ambient.gameObject.SetActive(true);
    }
    
    public void AmbientToPlayerUI()
    {
        playerUI.gameObject.SetActive(true);
        Ambient.gameObject.SetActive(false);
    }
    public void AmbientToControlls()
    {
        Ambient.gameObject.SetActive(false);
        Controlls.gameObject.SetActive(true);
    }
    
    public void ControllsToAmbient()
    {
        Ambient.gameObject.SetActive(true);
        Controlls.gameObject.SetActive(false);
    }
    public void ControllsToEvolveManager()
    {
        EvolveManager.gameObject.SetActive(true);
        Controlls.gameObject.SetActive(false);
    }
    public void EvolveManagerToControlls()
    {
        EvolveManager.gameObject.SetActive(false);
        Controlls.gameObject.SetActive(true);
    }
}
