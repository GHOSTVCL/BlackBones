using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Change_Room : MonoBehaviour
{
    private int roomCount;
    public int levelCount;
    private GameObject rooms;
    private RoomGeneration roomGenerationCount;
    private SaveRooms savedRooms;

    private void Start()
    {
        roomCount = 1;
        levelCount = 1;
        rooms = GameObject.Find("RoomManager");
        roomGenerationCount = rooms.GetComponent<RoomGeneration>();
        savedRooms = gameObject.GetComponent<SaveRooms>();
        DontDestroyOnLoad(gameObject);
    }
    private void OnTriggerEnter(Collider collision)
    {

        if(collision.tag == "Door")
        {
            if (roomGenerationCount.nLevelRooms != roomCount)
            {
                switch (roomCount)
                {
                    case 1:
                        roomCount = 2;
                        transform.position = new Vector3(100, 1, 0);
                        IntesityPerRoom(levelCount,roomCount);
                        break;
                    case 2:
                        roomCount = 3;
                        transform.position = new Vector3(200, 1, 0);
                        IntesityPerRoom(levelCount, roomCount);
                        break;
                    case 3:
                        roomCount = 4;
                        transform.position = new Vector3(300, 1, 0);
                        IntesityPerRoom(levelCount, roomCount);
                        break;
                    case 4:
                        roomCount = 5;
                        transform.position = new Vector3(400, 1, 0);
                        IntesityPerRoom(levelCount, roomCount);
                        break;
                    case 5:
                        roomCount = 6;
                        transform.position = new Vector3(500, 1, 0);
                        IntesityPerRoom(levelCount, roomCount);
                        break;
                }
            }
            else
            {
                levelCount = 2;
                //SceneManager.LoadScene("Level" + levelCount);
                SceneManager.LoadScene("Level2");
                roomCount = 1;
                rooms = GameObject.Find("RoomManager");
                roomGenerationCount = rooms.GetComponent<RoomGeneration>();
            }
        }
    }
    private void IntesityPerRoom(int level, int room)
    {
        switch (level)
        {
            case 1:
                roomGenerationCount.SelectOldIntensity(savedRooms.ambientLvl1, savedRooms.intesitysLvl1[room-1]);
                Debug.Log(savedRooms.intesitysLvl1[room - 1].ToString());
                break;
            case 2:
                roomGenerationCount.SelectOldIntensity(savedRooms.ambientLvl2, savedRooms.intesitysLvl2[room-1]);
                Debug.Log(savedRooms.intesitysLvl2[room - 1].ToString());
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
