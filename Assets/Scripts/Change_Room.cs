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

    private void Start()
    {
        roomCount = 1;
        levelCount = 1;
        rooms = GameObject.Find("RoomManager");
        roomGenerationCount = rooms.GetComponent<RoomGeneration>();
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
                        break;
                    case 2:
                        roomCount = 3;
                        transform.position = new Vector3(200, 1, 0);
                        break;
                    case 3:
                        roomCount = 4;
                        transform.position = new Vector3(300, 1, 0);
                        break;
                    case 4:
                        roomCount = 5;
                        transform.position = new Vector3(400, 1, 0);
                        break;
                    case 5:
                        roomCount = 6;
                        transform.position = new Vector3(500, 1, 0);
                        break;
                }
            }
            else
            {
                levelCount++;
                //SceneManager.LoadScene("Level" + levelCount);
                SceneManager.LoadScene("Level2");
                roomCount = 1;
                rooms = GameObject.Find("RoomManager");
                roomGenerationCount = rooms.GetComponent<RoomGeneration>();
            }
        }
    }
}
