using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Change_Room : MonoBehaviour
{
    private GameObject rooms;
    private RoomGeneration roomGenerationCount;
    private GameObject roomManager;
    private SaveRooms savedRooms;

    private player playerController;

    private GameObject simbolObject;
    private AmbientSimbol simbol;

    private bool aaaaa = false;


    private void Start()
    {
        roomManager = GameObject.Find("RoomManager");
        savedRooms = roomManager.GetComponent<SaveRooms>();
        playerController = gameObject.GetComponent<player>();
        simbolObject = GameObject.Find("UI");
        simbol = simbolObject.GetComponent<AmbientSimbol>();
        aaaaa = false;
        CheckIntensityCount(savedRooms.levelCount);
        gameObject.transform.position = new Vector3(0, 1, 0);

    }
    private void Update()
    {
        if(aaaaa == false && savedRooms.intesitysLvl1.Count != 0)
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
                transform.position = new Vector3(savedRooms.roomCount * 50, 1, 0);
                savedRooms.roomCount++;
                playerController.EvolveResistance(playerController.LevelAmbient(savedRooms.levelCount), playerController.LevelIntensity());
                simbol.asignIntensity(savedRooms.IntesityPerRoom(savedRooms.levelCount, savedRooms.roomCount));
                playerController.speed = playerController.baseSpeed;
                playerController.slowed = false;
            }
            else
            {
                if (savedRooms.levelCount == 5 && savedRooms.roomCount == savedRooms.nRoomsPerLevel[savedRooms.levelCount - 1])
                {
                    SceneManager.LoadScene("WinScene");
                    return;
                }
                savedRooms.roomCount = 1;
                SceneManager.LoadScene("EvolveScene");
            }
        }
    }

    private void CheckIntensityCount(int level)
    {
        switch(level)
        {
            case 1:
                if (savedRooms.intesitysLvl1.Count != 0)
                {
                    playerController.EvolveResistance(playerController.LevelAmbient(savedRooms.levelCount), playerController.LevelIntensity());
                    aaaaa = true;
                } break;
            case 2:
                if (savedRooms.intesitysLvl2.Count != 0)
                {
                    playerController.EvolveResistance(playerController.LevelAmbient(savedRooms.levelCount), playerController.LevelIntensity());
                    aaaaa = true;
                }
                break;
            case 3:
                if (savedRooms.intesitysLvl3.Count != 0)
                {
                    playerController.EvolveResistance(playerController.LevelAmbient(savedRooms.levelCount), playerController.LevelIntensity());
                    aaaaa = true;
                }
                break;
            case 4:
                if (savedRooms.intesitysLvl4.Count != 0)
                {
                    playerController.EvolveResistance(playerController.LevelAmbient(savedRooms.levelCount), playerController.LevelIntensity());
                    aaaaa = true;
                }
                break;
            case 5:
                if (savedRooms.intesitysLvl5.Count != 0)
                {
                    playerController.EvolveResistance(playerController.LevelAmbient(savedRooms.levelCount), playerController.LevelIntensity());
                    aaaaa = true;
                }
                break;
        }
    }
}
