using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Change_Room : MonoBehaviour
{
    private int levelCount;
    private GameObject rooms;
    private RoomGeneration roomGenerationCount;

    private void Start()
    {
        levelCount = 1;
        rooms = GameObject.Find("RoomManager");
        roomGenerationCount = rooms.GetComponent<RoomGeneration>();
    }
    private void OnTriggerEnter(Collider collision)
    {

        if(collision.tag == "Door")
        {
            if (roomGenerationCount.nLevelRooms != levelCount)
            {
                switch (levelCount)
                {
                    case 1:
                        levelCount = 2;
                        transform.position = new Vector3(15, 0, 0);
                        break;
                    case 2:
                        levelCount = 3;
                        transform.position = new Vector3(15, 0, 0);
                        break;
                    case 3:
                        levelCount = 4;
                        transform.position = new Vector3(25, 0, 0);
                        break;
                    case 4:
                        levelCount = 5;
                        transform.position = new Vector3(35, 0, 0);
                        break;
                    case 5:
                        levelCount = 6;
                        transform.position = new Vector3(45, 0, 0);
                        break;

                }
            }
            else
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
}
