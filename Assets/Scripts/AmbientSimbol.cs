using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class AmbientSimbol : MonoBehaviour
{
    [SerializeField] private Image Fire;
    [SerializeField] private Image Water;
    [SerializeField] private Image Ice;
    [SerializeField] private Image Toxic;
    [SerializeField] private Image Night;
    [SerializeField] private Image One;
    [SerializeField] private Image Two;
    [SerializeField] private Image Three;
    [SerializeField] private TextMeshProUGUI Intensitytext;
    [SerializeField] private RawImage overlay;
    public RoomGeneration Rm;

    void Start()
    {
        AsignSimbol(SaveRooms.instance.AccesAmbient(SaveRooms.instance.levelCount));
        asignIntensity(SaveRooms.instance.IntesityPerRoom(SaveRooms.instance.levelCount, SaveRooms.instance.roomCount));
        overlayChange(SaveRooms.instance.IntesityPerRoom(SaveRooms.instance.levelCount, SaveRooms.instance.roomCount), SaveRooms.instance.AccesAmbient(SaveRooms.instance.levelCount));
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
        else if (actualcolor == new Color(0f, 1f, 0f, 0.1f))
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
        if(intensity == 1)
        {
            One.gameObject.SetActive(true);
            Two.gameObject.SetActive(false);
            Three.gameObject.SetActive(false);
        }
        else if (intensity == 2)
        {
            One.gameObject.SetActive(false);
            Two.gameObject.SetActive(true);
            Three.gameObject.SetActive(false);
        }
        else if (intensity == 3)
        {
            One.gameObject.SetActive(false);
            Two.gameObject.SetActive(false);
            Three.gameObject.SetActive(true);
        }
    }
    public void overlayChange(int intensity, Color color)
    {
        if (color == new Color(1f, 0f, 0f, 0.1f))
        {
            switch(intensity)
            {
                case 1: overlay.color = new Color(0.8f, 0.2f, 0.2f, 0.1f);
                    break;
                case 2:
                    overlay.color = new Color(0.8f, 0.2f, 0.2f, 0.35f);
                    break;
                case 3:
                    overlay.color = new Color(0.8f, 0.2f, 0.2f, 0.75f);
                    break;
            }
        }
        else if (color == new Color(0f, 0f, 1f, 0.1f))
        {
            switch (intensity)
            {
                case 1:
                    overlay.color = new Color(0.2f,0.2f,0.8f, 0.1f);
                    break;
                case 2:
                    overlay.color = new Color(0.2f, 0.2f, 0.8f, 0.35f);
                    break;
                case 3:
                    overlay.color = new Color(0.2f, 0.2f, 0.8f, 0.75f);
                    break;
            }
        }
        else if (color == new Color(0f, 1f, 0f, 0.1f))
        {
            switch (intensity)
            {
                case 1:
                    overlay.color = new Color(0.2f,0.8f,0.2f, 0.1f);
                    break;
                case 2:
                    overlay.color = new Color(0.2f, 0.8f, 0.2f, 0.35f);
                    break;
                case 3:
                    overlay.color = new Color(0.2f, 0.8f, 0.2f, 0.75f);
                    break;
            }
        }
        else if (color == new Color(0f, 1f, 1f, 0.1f))
        {
            switch (intensity)
            {
                case 1:
                    overlay.color = new Color(0.2f, 0.8f, 0.8f, 0.1f);
                    break;
                case 2:
                    overlay.color = new Color(0.2f, 0.8f, 0.8f, 0.35f);
                    break;
                case 3:
                    overlay.color = new Color(0.2f, 0.8f, 0.8f, 0.75f);
                    break;
            }
        }
        else if (color == new Color(0f, 0f, 0f, 0.1f))
        {
            overlay.gameObject.SetActive(false);
            
        }
    }
}
