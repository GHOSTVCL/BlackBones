using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class RoomGeneration : MonoBehaviour
{
    [Header("ROOMS")]
    [SerializeField] GameObject Room1;
    [SerializeField] GameObject Room2;
    [SerializeField] GameObject Room3;
    [SerializeField] GameObject Room4;
    [SerializeField] GameObject Room5;

    [Header("AmbientCube")]
    [SerializeField] Light Light;
    private GameObject intesityImage;
    private RawImage intesityCanvas;

    private GameObject roomManager;
    private SaveRooms roomSaved;

    private Dictionary<int,GameObject> FireDictionary = new Dictionary<int,GameObject>();
    private Dictionary<int, GameObject> WaterDictionary = new Dictionary<int, GameObject>();
    private Dictionary<int, GameObject> ToxicDictionary = new Dictionary<int, GameObject>();
    private Dictionary<int, GameObject> DarkDictionary = new Dictionary<int, GameObject>();
    private Dictionary<int, GameObject> IceDictionary = new Dictionary<int, GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        AddRoomsToDictionary();

        roomManager = GameObject.Find("RoomManager");
        roomSaved = roomManager.GetComponent<SaveRooms>();
        intesityImage = GameObject.Find("Intensity");
        intesityCanvas = intesityImage.GetComponent<RawImage>();

        CheckRoomsExistence();

    }

    private Color SelectAmbient()
    {
        Color ambientColor = Color.white;
        int ambient = Random.Range(0,5);

        switch (ambient)
        {
            case 0:
                Light.color = ambientColor = new Color(1f, 0f, 0f, 0.1f);

                break;

            case 1:
                Light.color = ambientColor = new Color(0f, 0f, 1f, 0.1f);
                break;

            case 2:
                Light.color = ambientColor = new Color(0f, 1f, 0f,0.1f);
                break;

            case 3:
                Light.color = ambientColor = new Color(0f, 0f, 0f, 0.1f);
                break;

            case 4:
                Light.color = ambientColor = new Color(0f, 1f, 1f, 0.1f);
                break;

        }
        return ambientColor;
    }
    private void SelectOldAmbient(Color ambient)
    {
        if (ambient == new Color(1f, 0f, 0f, 0.1f))
        {
            Light.color = ambient;
        }
        else if (ambient == new Color(0f,0f,1f, 0.1f))
        {
           Light.color = ambient;
        }
        else if(ambient == new Color(0f,1f,0f, 0.1f))
        {
            Light.color = ambient;
        }
        else if (ambient == new Color(0f, 0f, 0f, 0.1f))
        {
            Light.color = ambient;
        }
        else if (ambient == new Color(0f, 1f, 1f, 0.1f))
        {
            Light.color = ambient;
        }
    }
    public int SelectNewIntensity(Color ambient)
    {
        int intesityR = Random.Range(1, 3);

        switch (intesityR)
        {
            case 1:
               intesityCanvas.color = new Color(ambient.r,ambient.g,ambient.b, 0.0f);
                break;

            case 2:
                intesityCanvas.color = new Color(ambient.r, ambient.g, ambient.b, 0.0f);
                break;

            case 3:
                intesityCanvas.color = new Color(ambient.r, ambient.g, ambient.b, 0.75f);
                break;
        }
        return intesityR;
    }
    public void SelectOldIntensity(Color ambient, int intensity)
    {
        switch (intensity)
        {
            case 1:
                intesityCanvas.color = new Color(ambient.r, ambient.g, ambient.b, 0.1f);
                break;

            case 2:
                intesityCanvas.color = new Color(ambient.r, ambient.g, ambient.b, 0.35f);
                break;

            case 3:
                intesityCanvas.color = new Color(ambient.r, ambient.g, ambient.b, 0.75f);
                break;
        }
    }
    private void CheckRoomsExistence()
    {
        if(roomSaved.levelCount == 0)
        {
            roomSaved.levelCount = 1;
        }
        switch (roomSaved.levelCount)
        {
            case 1:
                if (roomSaved.lvl1.Count == 0)
                {
                    roomSaved.ambientLvl1 = SelectAmbient();
                    GenerateNewRooms(roomSaved.lvl1, roomSaved.intesitysLvl1, roomSaved.ambientLvl1, roomSaved.nRoomsPerLevel[0]);
                    SelectOldIntensity(roomSaved.ambientLvl1, roomSaved.intesitysLvl1[0]);
                }
                else
                {
                    SelectOldAmbient(roomSaved.ambientLvl1);
                    SelectOldIntensity(roomSaved.ambientLvl1, roomSaved.intesitysLvl1[0]);
                    GenerateExistentRooms(roomSaved.lvl1, roomSaved.nRoomsPerLevel[0]);
                }
                break;
            case 2:
                if (roomSaved.lvl2.Count == 0)
                {
                    roomSaved.ambientLvl2 = SelectAmbient();
                    GenerateNewRooms(roomSaved.lvl2, roomSaved.intesitysLvl2, roomSaved.ambientLvl2, roomSaved.nRoomsPerLevel[1]);
                    SelectOldIntensity(roomSaved.ambientLvl1, roomSaved.intesitysLvl2[0]);
                }
                else
                {
                    SelectOldAmbient(roomSaved.ambientLvl2);
                    SelectOldIntensity(roomSaved.ambientLvl2, roomSaved.intesitysLvl2[0]);
                    GenerateExistentRooms(roomSaved.lvl2, roomSaved.nRoomsPerLevel[1]);
                }
                break;
            case 3:
                if (roomSaved.lvl3.Count == 0)
                {
                    roomSaved.ambientLvl3 = SelectAmbient();
                    GenerateNewRooms(roomSaved.lvl3, roomSaved.intesitysLvl3, roomSaved.ambientLvl3, roomSaved.nRoomsPerLevel[3]);
                    SelectOldIntensity(roomSaved.ambientLvl1, roomSaved.intesitysLvl3[0]);
                }
                else
                {
                    SelectOldAmbient(roomSaved.ambientLvl3);
                    SelectOldIntensity(roomSaved.ambientLvl3, roomSaved.intesitysLvl3[0]);
                    GenerateExistentRooms(roomSaved.lvl3, roomSaved.nRoomsPerLevel[2]);
                }
                break;
            case 4:
                if (roomSaved.lvl4.Count == 0)
                {
                    roomSaved.ambientLvl4 = SelectAmbient();
                    GenerateNewRooms(roomSaved.lvl4, roomSaved.intesitysLvl4, roomSaved.ambientLvl4, roomSaved.nRoomsPerLevel[3]);
                    SelectOldIntensity(roomSaved.ambientLvl1, roomSaved.intesitysLvl4[0]);
                }
                else
                {
                    SelectOldAmbient(roomSaved.ambientLvl4);
                    SelectOldIntensity(roomSaved.ambientLvl4, roomSaved.intesitysLvl4[0]);
                    GenerateExistentRooms(roomSaved.lvl4, roomSaved.nRoomsPerLevel[3]);
                }
                break;
            case 5:
                if (roomSaved.lvl5.Count == 0)
                {
                    roomSaved.ambientLvl5 = SelectAmbient();
                    GenerateNewRooms(roomSaved.lvl5, roomSaved.intesitysLvl5,roomSaved.ambientLvl5, roomSaved.nRoomsPerLevel[4]);
                    SelectOldIntensity(roomSaved.ambientLvl1, roomSaved.intesitysLvl1[5]);
                }
                else
                {
                    SelectOldAmbient(roomSaved.ambientLvl5);
                    SelectOldIntensity(roomSaved.ambientLvl5, roomSaved.intesitysLvl5[0]);
                    GenerateExistentRooms(roomSaved.lvl5, roomSaved.nRoomsPerLevel[4]);
                }
                break;
        }
    }
    private void GenerateExistentRooms(Dictionary<int,GameObject> roomDictionary, int nRooms)
    {
        for (int i = 0; i < nRooms; i++)
        {
            roomDictionary[i].transform.position = new Vector3(i * 200, 0, 0);
            Instantiate(roomDictionary[i]);
        }
    }

    private void GenerateNewRooms(Dictionary<int, GameObject> lvl, List<int> intensities, Color ambient, int nRooms)
    {
        Dictionary<int, GameObject> roomDictionary = SelectDictionary(ambient);

        for (int i = 0; i < nRooms; i++)
        {
            int room = Random.Range(0, 4);
            roomDictionary[room].transform.position = new Vector3(i * 200, 0, 0);
            Instantiate(roomDictionary[room]);
            lvl.Add(i,roomDictionary[room]);
            intensities.Add(SelectNewIntensity(ambient));
        }
    }

    private void AddRoomsToDictionary()
    {
        FireDictionary.Add(0, Room1);
        FireDictionary.Add(1, Room1);
        FireDictionary.Add(2, Room1);
        FireDictionary.Add(3, Room1);
        FireDictionary.Add(4, Room1);

        WaterDictionary.Add(0, Room2);
        WaterDictionary.Add(1, Room2);
        WaterDictionary.Add(2, Room2);
        WaterDictionary.Add(3, Room2);
        WaterDictionary.Add(4, Room2);

        ToxicDictionary.Add(0, Room3);
        ToxicDictionary.Add(1, Room3);
        ToxicDictionary.Add(2, Room3);
        ToxicDictionary.Add(3, Room3);
        ToxicDictionary.Add(4, Room3);

        DarkDictionary.Add(0, Room4);
        DarkDictionary.Add(1, Room4);
        DarkDictionary.Add(2, Room4);
        DarkDictionary.Add(3, Room4);
        DarkDictionary.Add(4, Room4);

        IceDictionary.Add(0, Room5);
        IceDictionary.Add(1, Room5);
        IceDictionary.Add(2, Room5);
        IceDictionary.Add(3, Room5);
        IceDictionary.Add(4, Room5);
    }

    private Dictionary<int, GameObject> SelectDictionary(Color ambient)
    {
        Dictionary<int, GameObject> roomDictionary = new Dictionary<int, GameObject>();
        if (ambient == new Color(1f, 0f, 0f, 0.1f))
        {
            roomDictionary = FireDictionary;
        }
        else if (ambient == new Color(0f, 0f, 1f, 0.1f))
        {
            roomDictionary = WaterDictionary;
        }
        else if (ambient == new Color(0f, 1f, 0f, 0.1f))
        {
            roomDictionary = ToxicDictionary;
        }
        else if (ambient == new Color(0f, 0f, 0f, 0.1f))
        {
            roomDictionary = DarkDictionary;
        }
        else if (ambient == new Color(0f, 1f, 1f, 0.1f))
        {
            roomDictionary = IceDictionary;
        }
        return roomDictionary;
    }
}
