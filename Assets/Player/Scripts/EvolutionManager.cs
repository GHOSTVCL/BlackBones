using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvolutionManager : MonoBehaviour
{
    static public EvolutionManager instance { get; private set; }
    public int FireEvolution = 0;
    public int WaterEvolution = 0;
    public int ToxicEvolution = 0;
    public int IceEvolution = 0;
    public int nightEvolution = 0;

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
