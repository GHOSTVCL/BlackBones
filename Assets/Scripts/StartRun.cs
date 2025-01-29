using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartRun : MonoBehaviour
{
    private GameObject roomManager;
    private SaveRooms savedRooms;


    private void Start()
    {
        roomManager = GameObject.Find("RoomManager");
        savedRooms = roomManager.GetComponent<SaveRooms>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "FirstDoor")
        {
            savedRooms.levelCount = 0;
            savedRooms.roomCount = 1;
            Invoke("ToEvolveScreen",1);
        }
    }
    private void ToEvolveScreen()
    {
        SceneManager.LoadScene("EvolveScene");
    }
}
