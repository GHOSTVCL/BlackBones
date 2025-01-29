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
   
   public void BacktoMenu()
    {
        
    }
    public void playerUIToControlls()
    {
        playerUI.gameObject.SetActive(false);
        Controlls.gameObject.SetActive(true);
    }
    public void ControllsToPlayerUI()
    {
        playerUI.gameObject.SetActive(true);
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
