using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class FullScreenLogic : MonoBehaviour
{
    public Toggle toggle;
    //public TMP_Dropdown resolucionesDropDown;
    //Resolution[] resoluciones;
    
    private void Start()
    {
        //RevisarResolucion();
        if (Screen.fullScreen)
        {
            toggle.isOn = true;
            CambiarResolucion();
        }
        else
        {
            toggle.isOn = false;
            CambiarResolucionMinima();
        }

        
    }
    //public void RevisarResolucion()
    //{
    //    resoluciones = Screen.resolutions;
    //    resolucionesDropDown.ClearOptions();
    //    List<string> opciones = new List<string>();
    //    int resolucionActual = 0;

    //    for (int i = 0; i < resoluciones.Length; i++)
    //    {
    //        string opcion = resoluciones[i].width + " x " + resoluciones[i].height;
    //        opciones.Add(opcion);

    //        if (Screen.fullScreen && resoluciones[i].width == Screen.currentResolution.width && resoluciones[i].height == Screen.currentResolution.height)
    //        {
    //            resolucionActual = i;
    //        }
    //    }

    //    resolucionesDropDown.AddOptions(opciones);
    //    resolucionesDropDown.value = resolucionActual;
    //    resolucionesDropDown.RefreshShownValue();

    //    resolucionesDropDown.value = PlayerPrefs.GetInt("numeroResolucion", 0);
    //}

    public void CambiarResolucion()
    {
        //Resolution resolucion = resoluciones[indiceResolucion];
        Screen.SetResolution(1980, 1220, Screen.fullScreen);
    }

    public void CambiarResolucionMinima()
    {
        //Resolution resolucion = resoluciones[indiceResolucion];
        Screen.SetResolution(800, 600, Screen.fullScreen);
    }

    public void SetFullScreen(bool isfullscreen)
    {
        if(isfullscreen)
        {
            CambiarResolucion();
        }
        else
        {
            CambiarResolucionMinima();
        }
        Screen.fullScreen = isfullscreen;
    }
}
