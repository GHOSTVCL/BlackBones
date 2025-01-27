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
