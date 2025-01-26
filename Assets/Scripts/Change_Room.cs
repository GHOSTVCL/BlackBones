using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Change_Room : MonoBehaviour
{
    private GameObject rooms;
    private RoomGeneration roomGenerationCount;
    private GameObject roomManager;
    private SaveRooms savedRooms;

    private player playerController;

    private AmbientSimbol simbol;

    private bool aaaaa = false;


    private void Start()
    {
        roomManager = GameObject.Find("RoomManager");
        savedRooms = roomManager.GetComponent<SaveRooms>();
        playerController = gameObject.GetComponent<player>();
        simbol = gameObject.AddComponent<AmbientSimbol>();
        aaaaa = false;
        if (savedRooms.intesitysLvl1.Count != 0)
        {
            playerController.EvolveResistance(playerController.LevelAmbient(savedRooms.levelCount), playerController.LevelIntensity());
            aaaaa = true;
        }
        gameObject.transform.position = new Vector3(0, 2, 0);

    }
    private void Update()
    {
        if(aaaaa == false)
        {
            playerController.EvolveResistance(playerController.LevelAmbient(savedRooms.levelCount), playerController.LevelIntensity());
            aaaaa = true;
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Door")
        {
            if(savedRooms.roomCount == 0)
            {
                savedRooms.roomCount = 1;
            }
            if (savedRooms.nRoomsPerLevel[savedRooms.levelCount - 1] != savedRooms.roomCount)
            {
                transform.position = new Vector3(savedRooms.roomCount * 200, 2, 0);
                savedRooms.roomCount++;
                playerController.EvolveResistance(playerController.LevelAmbient(savedRooms.levelCount), playerController.LevelIntensity());
                simbol.asignIntensity(savedRooms.IntesityPerRoom(savedRooms.levelCount, savedRooms.roomCount));
                playerController.slowed = false;
            }
            else
            {
                savedRooms.roomCount = 1;
                SceneManager.LoadScene("EvolveScene");
            }
        }
    }
}
