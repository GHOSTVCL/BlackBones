using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalManager : MonoBehaviour
{
    private int finalEvolution;

    [SerializeField] GameObject NoMutations;
    [SerializeField] GameObject ItsAMatch;
    [SerializeField] GameObject ViolentEnding;



    private int NOnumber = 1;
    private GameObject NO;
    // Start is called before the first frame update
    void Start()
    {
        finalEvolution = EvolutionManager.instance.FireEvolution + EvolutionManager.instance.WaterEvolution +
            EvolutionManager.instance.ToxicEvolution + EvolutionManager.instance.nightEvolution + EvolutionManager.instance.IceEvolution;
    }

    // Update is called once per frame
    void Update()
    {
        if (finalEvolution <= 10)
        {
            NoMutations.SetActive(true);
        }
        else if (finalEvolution > 10 && finalEvolution <= 30)
        {
            ItsAMatch.SetActive(true);
        }
        else if (finalEvolution > 30)
        {
            ViolentEnding.SetActive(true);
        }
    }
}
