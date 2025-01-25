using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveRooms : MonoBehaviour
{
    [HideInInspector] 
    public Dictionary<int, GameObject> lvl1 = new Dictionary<int, GameObject>();
    [HideInInspector]
    public Dictionary<int, GameObject> lvl2 = new Dictionary<int, GameObject>();
    public Dictionary<int, GameObject> lvl3 = new Dictionary<int, GameObject>();
    [HideInInspector]
    public Dictionary<int, GameObject> lvl4 = new Dictionary<int, GameObject>();
    [HideInInspector]
    public Dictionary<int, GameObject> lvl5 = new Dictionary<int, GameObject>();

    [HideInInspector]
    public Color ambientLvl1;
    [HideInInspector]
    public Color ambientLvl2;
    [HideInInspector]
    public Color ambientLvl3;
    [HideInInspector]
    public Color ambientLvl4;
    [HideInInspector]
    public Color ambientLvl5;

    [HideInInspector]
    public List<int> intesitysLvl1 = new List<int>();
    [HideInInspector]
    public List<int> intesitysLvl2 = new List<int>();
    [HideInInspector]
    public List<int> intesitysLvl3 = new List<int>();
    [HideInInspector]
    public List<int> intesitysLvl4 = new List<int>();
    [HideInInspector]
    public List<int> intesitysLvl5 = new List<int>();

    [HideInInspector]
    public int roomCount;
    [HideInInspector]
    public int levelCount;

    private void Start()
    {
        levelCount = 1;
        roomCount = 1;
        DontDestroyOnLoad(gameObject);
    }
}
