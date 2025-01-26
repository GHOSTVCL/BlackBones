using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public string scene;

    public void ChangeScene()
    {
        SceneManager.LoadScene(scene);
    }
}
