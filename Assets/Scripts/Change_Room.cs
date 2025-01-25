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

    private GameObject player;
    private player playerController;


    private void Start()
    {
        rooms = GameObject.Find("RoomGenerator");
        roomManager = GameObject.Find("RoomManager");
        player = GameObject.Find("Rename");

        roomGenerationCount = rooms.GetComponent<RoomGeneration>();
        savedRooms = roomManager.GetComponent<SaveRooms>();
        playerController = player.GetComponent<player>();
        playerController.EvolveResistance(playerController.LevelAmbient(savedRooms.levelCount), playerController.LevelIntensity());

        gameObject.transform.position = new Vector3(0, 2, 0);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Door")
        {
            if(savedRooms.roomCount == 0)
            {
                savedRooms.roomCount = 1;
            }
            if (roomGenerationCount.nLevelRooms != savedRooms.roomCount)
            {
                switch (savedRooms.roomCount)
                {
                    case 1:
                        savedRooms.roomCount = 2;
                        transform.position = new Vector3(200, 2, 0);
                        IntesityPerRoom(savedRooms.levelCount, savedRooms.roomCount);
                        playerController.EvolveResistance(playerController.LevelAmbient(savedRooms.levelCount),playerController.LevelIntensity());
                        playerController.slowed = false;
                        break;
                    case 2:
                        savedRooms.roomCount = 3;
                        transform.position = new Vector3(400, 2, 0);
                        IntesityPerRoom(savedRooms.levelCount, savedRooms.roomCount);
                        playerController.EvolveResistance(playerController.LevelAmbient(savedRooms.levelCount), playerController.LevelIntensity());
                        playerController.slowed = false;
                        break;
                    case 3:
                        savedRooms.roomCount = 4;
                        transform.position = new Vector3(600, 2, 0);
                        IntesityPerRoom(savedRooms.levelCount, savedRooms.roomCount);
                        playerController.EvolveResistance(playerController.LevelAmbient(savedRooms.levelCount), playerController.LevelIntensity());
                        playerController.slowed = false;
                        break;
                    case 4:
                        savedRooms.roomCount = 5;
                        transform.position = new Vector3(800, 2, 0);
                        IntesityPerRoom(savedRooms.levelCount, savedRooms.roomCount);
                        playerController.EvolveResistance(playerController.LevelAmbient(savedRooms.levelCount), playerController.LevelIntensity());
                        playerController.slowed = false;
                        break;
                    case 5:
                        savedRooms.roomCount = 6;
                        transform.position = new Vector3(1000, 2, 0);
                        IntesityPerRoom(savedRooms.levelCount, savedRooms.roomCount);
                        playerController.EvolveResistance(playerController.LevelAmbient(savedRooms.levelCount), playerController.LevelIntensity());
                        playerController.slowed = false;
                        break;
                }
            }
            else
            {
                SceneManager.LoadScene("EvolveScene");
            }
        }
    }
    private void IntesityPerRoom(int level, int room)
    {
        switch (level)
        {
            case 1:
                roomGenerationCount.SelectOldIntensity(savedRooms.ambientLvl1, savedRooms.intesitysLvl1[room-1]);
                break;
            case 2:
                roomGenerationCount.SelectOldIntensity(savedRooms.ambientLvl2, savedRooms.intesitysLvl2[room-1]);
                break;
            case 3:
                roomGenerationCount.SelectOldIntensity(savedRooms.ambientLvl3, savedRooms.intesitysLvl3[room - 1]);
                
                break;
            case 4:
                roomGenerationCount.SelectOldIntensity(savedRooms.ambientLvl4, savedRooms.intesitysLvl4[room - 1]);
                break;
            case 5:
                roomGenerationCount.SelectOldIntensity(savedRooms.ambientLvl5, savedRooms.intesitysLvl5[room - 1]);
                break;
        }
    }

    
}
