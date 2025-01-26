using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class AmbientSimbol : MonoBehaviour
{
    [SerializeField] private Image Fire;
    [SerializeField] private Image Water;
    [SerializeField] private Image Ice;
    [SerializeField] private Image Toxic;
    [SerializeField] private Image Night;
    [SerializeField] private TextMeshProUGUI Intensitytext;
    public RoomGeneration Rm;
    void Start()
    {
        AsignSimbol(SaveRooms.instance.AccesAmbient(SaveRooms.instance.levelCount));
        asignIntensity(SaveRooms.instance.IntesityPerRoom(SaveRooms.instance.levelCount, SaveRooms.instance.roomCount));
    }

   private void AsignSimbol(Color Ambient)
    {
        Color actualcolor = Ambient;
       if(actualcolor == new Color(1f, 0f, 0f, 0.1f))
        {
            Fire.gameObject.SetActive(true);
            Water.gameObject.SetActive(false);
            Ice.gameObject.SetActive(false);
            Toxic.gameObject.SetActive(false);
            Night.gameObject.SetActive(false);
        }
        else if (actualcolor == new Color(0f, 0f, 1f, 0.1f))
        {
            Fire.gameObject.SetActive(false);
            Water.gameObject.SetActive(true);
            Ice.gameObject.SetActive(false);
            Toxic.gameObject.SetActive(false);
            Night.gameObject.SetActive(false);
        }
        else if (actualcolor == new Color(0f, 0f, 1f, 0.1f))
        {
            Fire.gameObject.SetActive(false);
            Water.gameObject.SetActive(false);
            Ice.gameObject.SetActive(false);
            Toxic.gameObject.SetActive(true);
            Night.gameObject.SetActive(false);
        }
        else if (actualcolor == new Color(0f, 1f, 1f, 0.1f))
        {
            Fire.gameObject.SetActive(false);
            Water.gameObject.SetActive(false);
            Ice.gameObject.SetActive(true);
            Toxic.gameObject.SetActive(false);
            Night.gameObject.SetActive(false);
        }
        else if (actualcolor == new Color(0f, 0f, 0f, 0.1f))
        {
            Fire.gameObject.SetActive(false);
            Water.gameObject.SetActive(false);
            Ice.gameObject.SetActive(false);
            Toxic.gameObject.SetActive(false);
            Night.gameObject.SetActive(true);
        }
    }
    public void asignIntensity(int intensity)
    {
        Intensitytext.text = intensity.ToString();
    }
}
