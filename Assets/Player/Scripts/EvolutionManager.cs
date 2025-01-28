using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EvolutionManager : MonoBehaviour
{
    static public EvolutionManager instance { get; private set; }
    public int FireEvolution;
    public int WaterEvolution;
    public int ToxicEvolution;
    public int IceEvolution;
    public int nightEvolution;

    [HideInInspector]
    public int savedFire = 0;
    [HideInInspector]
    public int savedWater = 0;
    [HideInInspector]
    public int savedToxic = 0;
    [HideInInspector]
    public int savedIce = 0;
    [HideInInspector]
    public int savedNight = 0;

    private void Awake()
    {

        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {

            instance = this;

            DontDestroyOnLoad(gameObject);
        }
    }

}
