using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveRooms : MonoBehaviour
{
    [HideInInspector]
    public Dictionary<int, GameObject> lvl1 = new Dictionary<int, GameObject>();
    public Dictionary<int, GameObject> lvl2 = new Dictionary<int, GameObject>();
    public Dictionary<int, GameObject> lvl3 = new Dictionary<int, GameObject>();
    public Dictionary<int, GameObject> lvl4 = new Dictionary<int, GameObject>();
    public Dictionary<int, GameObject> lvl5 = new Dictionary<int, GameObject>();

}
