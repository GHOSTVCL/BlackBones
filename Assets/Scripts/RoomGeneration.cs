using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class RoomGeneration : MonoBehaviour
{
    [Header("ROOMS")]
    [SerializeField] GameObject Room1;
    [SerializeField] GameObject Room2;
    [SerializeField] GameObject Room3;
    [SerializeField] GameObject Room4;
    [SerializeField] GameObject Room5;

    [Header("NLevelRooms")]
    [SerializeField] public int nLevelRooms;

    [Header("AmbientCube")]
    [SerializeField] Light Light;

    [SerializeField] int level;

    private GameObject player;
    private SaveRooms roomSaved;

    private Dictionary<int,GameObject> RoomsDictionary = new Dictionary<int,GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        RoomsDictionary.Add(0, Room1);
        RoomsDictionary.Add(1, Room2);
        RoomsDictionary.Add(2, Room3);
        RoomsDictionary.Add(3, Room4);
        RoomsDictionary.Add(4, Room5);

        player = GameObject.Find("Hero_Idle_0");
        roomSaved = player.GetComponent<SaveRooms>();

        CheckRoomsExistence();

    }

    private void SelectAmbient()
    {
        int ambient = Random.Range(0,5);

        switch (ambient)
        {
            case 0:
                Light.color = new Color(255, 0, 0);
                break;

            case 1:
                Light.color = new Color(0f, 0f, 255f);
                break;

            case 2:
                Light.color = new Color(0f, 255f, 0f);
                break;

            case 3:
                Light.color = new Color(0f, 0f, 0f);
                break;

            case 4:
                Light.color = new Color(0f, 255f, 255f);
                break;

        }
    }
    public void SelectIntensity()
    {
        int intesityR = Random.Range(0, 3);

        switch (intesityR)
        {
            case 0:
                Light.intensity = 3f;
                break;

            case 1:
                Light.intensity = 5f;
                break;

            case 2:
                Light.intensity = 10f;
                break;
        }
    }
    private void CheckRoomsExistence()
    {
        switch (level)
        {
            case 1:
                if (roomSaved.lvl1.Count == 0)
                {
                    GenerateNewRooms(RoomsDictionary, roomSaved.lvl1);
                }
                else
                {
                    GenerateExistentRooms(roomSaved.lvl1, roomSaved.lvl1.Count);
                }
                break;
            case 2:
                if (roomSaved.lvl2.Count == 0)

                {
                    GenerateNewRooms(RoomsDictionary, roomSaved.lvl2);
                }
                else
                {
                    GenerateExistentRooms(roomSaved.lvl2, roomSaved.lvl2.Count);
                }
                break;
            case 3:
                if (roomSaved.lvl3.Count == 0)
                {
                    GenerateNewRooms(RoomsDictionary, roomSaved.lvl3);
                }
                else
                {
                    GenerateExistentRooms(roomSaved.lvl3, roomSaved.lvl3.Count);
                }
                break;
            case 4:
                if (roomSaved.lvl4.Count == 0)
                {
                    GenerateNewRooms(RoomsDictionary, roomSaved.lvl4);
                }
                else
                {
                    GenerateExistentRooms(roomSaved.lvl4, roomSaved.lvl4.Count);
                }
                break;
            case 5:
                if (roomSaved.lvl5.Count == 0)
                {
                    GenerateNewRooms(RoomsDictionary, roomSaved.lvl5);
                }
                else
                {
                    GenerateExistentRooms(roomSaved.lvl5, roomSaved.lvl5.Count);
                }
                break;
        }
    }
    private void GenerateExistentRooms(Dictionary<int,GameObject> roomDictionary, int nRooms)
    {
        for (int i = 0; i < nRooms; i++)
        {
            roomDictionary[i].transform.position = new Vector3(i * 100, 0, 0);
            Instantiate(roomDictionary[i]);
        }
    }

    private void GenerateNewRooms(Dictionary<int, GameObject> roomDictionary, Dictionary<int, GameObject> lvl)
    {
        SelectAmbient();
        for (int i = 0; i < nLevelRooms; i++)
        {
            int room = Random.Range(0, 5);
            roomDictionary[room].transform.position = new Vector3(i * 100, 0, 0);
            Instantiate(roomDictionary[room]);
            lvl.Add(i,roomDictionary[room]);
        }
    }

}
