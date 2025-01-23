using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
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
    [SerializeField] Renderer cubeAmbient;

    private Dictionary<int,GameObject> RoomsDictionary = new Dictionary<int,GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        RoomsDictionary.Add(0, Room1);
        RoomsDictionary.Add(1, Room2);
        RoomsDictionary.Add(2, Room3);
        RoomsDictionary.Add(3, Room4);
        RoomsDictionary.Add(4, Room5);
        SelectAmbient();

        for (int i = 0; i< nLevelRooms; i++)
        {
            int room = Random.Range(0, 5);
            RoomsDictionary[room].transform.position = new Vector3(i * 10, 0, 0);
            Instantiate(RoomsDictionary[room]);
        }
    }

    private void SelectAmbient()
    {
        int ambient = Random.Range(0,5);

        switch (ambient)
        {
            case 0:
                cubeAmbient.material.color = new Color(255f, 0f, 0f, SelectIntensity());
                break;

            case 1:
                cubeAmbient.material.color = new Color(0f, 0f, 255f, SelectIntensity());
                break;

            case 2:
                cubeAmbient.material.color = new Color(0f, 255f, 0f, SelectIntensity());
                break;

            case 3:
                cubeAmbient.material.color = new Color(0f, 0f, 0f, SelectIntensity());
                break;

            case 4:
                cubeAmbient.material.color = new Color(0f, 255f, 255f, SelectIntensity());
                break;

        }
    }
    private float SelectIntensity()
    {
        int intesityR = Random.Range(0, 3);
        float intesity = 0f;

        switch (intesityR)
        {
            case 0:
                intesity = 0.01f;
                break;

            case 1:
                intesity = 0.02f;
                break;

            case 2:
                intesity = 0.03f;
                break;

        }
        return intesity;
    }
}
