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


    private void Start()
    {
        rooms = GameObject.Find("RoomGenerator");
        roomManager = GameObject.Find("RoomManager");

        roomGenerationCount = rooms.GetComponent<RoomGeneration>();
        savedRooms = roomManager.GetComponent<SaveRooms>();
        playerController = gameObject.GetComponent<player>();

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
            if (savedRooms.nRoomsPerLevel[savedRooms.levelCount - 1] != savedRooms.roomCount)
            {
                transform.position = new Vector3(savedRooms.roomCount * 200, 2, 0);
                IntesityPerRoom(savedRooms.levelCount, savedRooms.roomCount);
                savedRooms.roomCount++;
                playerController.EvolveResistance(playerController.LevelAmbient(savedRooms.levelCount), playerController.LevelIntensity());
                playerController.slowed = false;
            }
            else
            {
                savedRooms.roomCount = 1;
                SceneManager.LoadScene("EvolveScene");
            }
        }
    }
    private void IntesityPerRoom(int level, int room)
    {
        switch (level)
        {
            case 1:
                roomGenerationCount.SelectOldIntensity(savedRooms.ambientLvl1, savedRooms.intesitysLvl1[savedRooms.roomCount-1]);
                break;
            case 2:
                roomGenerationCount.SelectOldIntensity(savedRooms.ambientLvl2, savedRooms.intesitysLvl2[savedRooms.roomCount - 1]);
                break;
            case 3:
                roomGenerationCount.SelectOldIntensity(savedRooms.ambientLvl3, savedRooms.intesitysLvl3[savedRooms.roomCount - 1]);
                
                break;
            case 4:
                roomGenerationCount.SelectOldIntensity(savedRooms.ambientLvl4, savedRooms.intesitysLvl4[savedRooms.roomCount - 1]);
                break;
            case 5:
                roomGenerationCount.SelectOldIntensity(savedRooms.ambientLvl5, savedRooms.intesitysLvl5[savedRooms.roomCount - 1]);
                break;
        }
    }
}
