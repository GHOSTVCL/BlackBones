using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class RoomGeneration : MonoBehaviour
{
    [Header("FireRooms")]
    [SerializeField] GameObject RoomF1;
    [SerializeField] GameObject RoomF2;
    [SerializeField] GameObject RoomF3;
    [SerializeField] GameObject RoomF4;

    [Header("WaterRooms")]
    [SerializeField] GameObject RoomW1;
    [SerializeField] GameObject RoomW2;
    [SerializeField] GameObject RoomW3;
    [SerializeField] GameObject RoomW4;

    [Header("ToxicRooms")]
    [SerializeField] GameObject RoomT1;
    [SerializeField] GameObject RoomT2;
    [SerializeField] GameObject RoomT3;
    [SerializeField] GameObject RoomT4;

    [Header("DarkRooms")]
    [SerializeField] GameObject RoomD1;
    [SerializeField] GameObject RoomD2;
    [SerializeField] GameObject RoomD3;
    [SerializeField] GameObject RoomD4;

    [Header("IceRooms")]
    [SerializeField] GameObject RoomI1;
    [SerializeField] GameObject RoomI2;
    [SerializeField] GameObject RoomI3;
    [SerializeField] GameObject RoomI4;

    [Header("AmbientCube")]
    [SerializeField] Light Light;
    [SerializeField] Light Light2;

    [Header("AmbientCube")]
    [SerializeField] GameObject shader;
    [SerializeField] Material mat1;
    [SerializeField] Material mat2;
    [SerializeField] Material mat3;
    [SerializeField] Material mat4;
    [SerializeField] Material mat5;
    private Renderer shaderRenderer;

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

        

        CheckRoomsExistence();

    }

    private Color SelectAmbient()
    {
        Color ambientColor = Color.white;
        int ambient = Random.Range(0,5);

        switch (ambient)
        {
            case 0:
                Light.transform.localEulerAngles = new Vector3(50, -30, 0);
                ambientColor = new Color(1f, 0f, 0f, 0.1f);
                Light.color = new Color(0.7f, 0f, 0f, 0.1f);
                shader.GetComponent<Renderer>().material = mat1;
                break;

            case 1:
                Light.transform.localEulerAngles = new Vector3(50, -30, 0);
                ambientColor = new Color(0f, 0f, 1f, 0.1f);
                Light.color = new Color(0f, 0f, 0.7f, 0.1f);
                shader.GetComponent<Renderer>().material = mat2;
                break;

            case 2:
                Light.transform.localEulerAngles = new Vector3(50, -30, 0);
                ambientColor = new Color(0f, 1f, 0f, 0.1f);
                Light.color = new Color(0f, 0.7f, 0f, 0.1f);
                shader.GetComponent<Renderer>().material = mat3;
                break;

            case 3:
                Light.color = ambientColor = new Color(0f, 0f, 0f, 0.1f);
                shader.GetComponent<Renderer>().material = mat4;
                break;

            case 4:
                Light.transform.localEulerAngles = new Vector3(50, -30, 0);
                ambientColor = new Color(0f, 1f, 1f, 0.1f);
                Light.color = new Color(0f, 0.7f, 0.7f, 0.1f);
                shader.GetComponent<Renderer>().material = mat5;
                break;

        }
        return ambientColor;
    }
    private void SelectOldAmbient(Color ambient)
    {
        if (ambient == new Color(1f, 0f, 0f, 0.1f))
        {
            //Light.color = ambient;
            Light.color = new Color(0.7f, 0f, 0f, 0.1f);
            Light.transform.localEulerAngles = new Vector3(50, -30, 0);
            shader.GetComponent<Renderer>().material = mat1;
        }
        else if (ambient == new Color(0f,0f,1f, 0.1f))
        {
            //Light.color = ambient;
            Light.color = new Color(0f, 0f, 0.7f, 0.1f);
            Light.transform.localEulerAngles = new Vector3(50, -30, 0);
            shader.GetComponent<Renderer>().material = mat2;
        }
        else if(ambient == new Color(0f,1f,0f, 0.1f))
        {
            //Light.color = ambient;
            Light.color = new Color(0f, 0.7f, 0f, 0.1f);
            Light.transform.localEulerAngles = new Vector3(50, -30, 0);
            shader.GetComponent<Renderer>().material = mat3;
        }
        else if (ambient == new Color(0f, 0f, 0f, 0.1f))
        {
            Light.color = ambient;
            
            shader.GetComponent<Renderer>().material = mat4;
        }
        else if (ambient == new Color(0f, 1f, 1f, 0.1f))
        {
            //Light.color = ambient;
            Light.color = new Color(0f, 0.7f, 0.7f, 0.1f);
            Light.transform.localEulerAngles = new Vector3(50, -30, 0);
            shader.GetComponent<Renderer>().material = mat5;
        }
    }
    public int SelectNewIntensity(Color ambient)
    {
        int intesityR = Random.Range(1, 4);

        return intesityR;
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
                }
                else
                {
                    SelectOldAmbient(roomSaved.ambientLvl1);
                    GenerateExistentRooms(roomSaved.lvl1, roomSaved.nRoomsPerLevel[0]);
                }
                break;
            case 2:
                if (roomSaved.lvl2.Count == 0)
                {
                    roomSaved.ambientLvl2 = SelectAmbient();
                    GenerateNewRooms(roomSaved.lvl2, roomSaved.intesitysLvl2, roomSaved.ambientLvl2, roomSaved.nRoomsPerLevel[1]);
                }
                else
                {
                    SelectOldAmbient(roomSaved.ambientLvl2);
                    GenerateExistentRooms(roomSaved.lvl2, roomSaved.nRoomsPerLevel[1]);
                }
                break;
            case 3:
                if (roomSaved.lvl3.Count == 0)
                {
                    roomSaved.ambientLvl3 = SelectAmbient();
                    GenerateNewRooms(roomSaved.lvl3, roomSaved.intesitysLvl3, roomSaved.ambientLvl3, roomSaved.nRoomsPerLevel[2]);
                }
                else
                {
                    SelectOldAmbient(roomSaved.ambientLvl3);
                    GenerateExistentRooms(roomSaved.lvl3, roomSaved.nRoomsPerLevel[2]);
                }
                break;
            case 4:
                if (roomSaved.lvl4.Count == 0)
                {
                    roomSaved.ambientLvl4 = SelectAmbient();
                    GenerateNewRooms(roomSaved.lvl4, roomSaved.intesitysLvl4, roomSaved.ambientLvl4, roomSaved.nRoomsPerLevel[3]);
                }
                else
                {
                    SelectOldAmbient(roomSaved.ambientLvl4);
                    GenerateExistentRooms(roomSaved.lvl4, roomSaved.nRoomsPerLevel[3]);
                }
                break;
            case 5:
                if (roomSaved.lvl5.Count == 0)
                {
                    roomSaved.ambientLvl5 = SelectAmbient();
                    GenerateNewRooms(roomSaved.lvl5, roomSaved.intesitysLvl5,roomSaved.ambientLvl5, roomSaved.nRoomsPerLevel[4]);
                }
                else
                {
                    SelectOldAmbient(roomSaved.ambientLvl5);
                    GenerateExistentRooms(roomSaved.lvl5, roomSaved.nRoomsPerLevel[4]);
                }
                break;
        }
    }
    private void GenerateExistentRooms(Dictionary<int,GameObject> roomDictionary, int nRooms)
    {
        for (int i = 0; i < nRooms; i++)
        {
            roomDictionary[i].transform.position = new Vector3(i * 50, 0, 0);
            Instantiate(roomDictionary[i]);
        }
    }

    private void GenerateNewRooms(Dictionary<int, GameObject> lvl, List<int> intensities, Color ambient, int nRooms)
    {
        Dictionary<int, GameObject> roomDictionary = SelectDictionary(ambient);

        for (int i = 0; i < nRooms; i++)
        {
            int room = Random.Range(0, 4);
            roomDictionary[room].transform.position = new Vector3(i * 50, 0, 0);
            Instantiate(roomDictionary[room]);
            lvl.Add(i,roomDictionary[room]);
            intensities.Add(SelectNewIntensity(ambient));
        }
    }

    private void AddRoomsToDictionary()
    {
        FireDictionary.Add(0, RoomF1);
        FireDictionary.Add(1, RoomF2);
        FireDictionary.Add(2, RoomF3);
        FireDictionary.Add(3, RoomF4);

        WaterDictionary.Add(0, RoomW1);
        WaterDictionary.Add(1, RoomW2);
        WaterDictionary.Add(2, RoomW3);
        WaterDictionary.Add(3, RoomW4);

        ToxicDictionary.Add(0, RoomT1);
        ToxicDictionary.Add(1, RoomT2);
        ToxicDictionary.Add(2, RoomT3);
        ToxicDictionary.Add(3, RoomT4);

        DarkDictionary.Add(0, RoomD1);
        DarkDictionary.Add(1, RoomD2);
        DarkDictionary.Add(2, RoomD3);
        DarkDictionary.Add(3, RoomD4);

        IceDictionary.Add(0, RoomI1);
        IceDictionary.Add(1, RoomI2);
        IceDictionary.Add(2, RoomI3);
        IceDictionary.Add(3, RoomI4);
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
