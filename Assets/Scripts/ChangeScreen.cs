using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public string scene;

    public void InvokeChange()
    {
        Invoke("ChangeScene", 1);
    }
    public void ChangeScene()
    {
        if ((SceneManager.GetActiveScene().name == "TitleScreen") && gameObject.name == "Start")
        {
            SaveRooms.instance.ResetRooms();
        }
        SceneManager.LoadScene(scene);
    }
}
