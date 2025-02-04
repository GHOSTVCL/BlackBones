using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private GameObject RoomManager;
    private SaveRooms saveRooms;
    // Start is called before the first frame update
    void Start()
    {
        RoomManager = GameObject.Find("RoomManager");
        saveRooms = RoomManager.GetComponent<SaveRooms>();
    }

    // Update is called once per frame
    public void NextLevelFunction()
    {
        saveRooms.levelCount++;
        saveRooms.roomCount = 1;
        SceneManager.LoadScene("LevelScene");
        
    }

    public void InvokeNext()
    {
        Invoke("NextLevelFunction", 1);
    }
}
