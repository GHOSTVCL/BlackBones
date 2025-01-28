using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggSpawner : MonoBehaviour
{
    [SerializeField] GameObject egg1;
    [SerializeField] GameObject egg2;
    [SerializeField] GameObject egg3;
    // Start is called before the first frame update
    void Start()
    {
        spawnEggs(GameManager.instance.lifes);
    }

    private void spawnEggs(float lifes)
    {
        switch (lifes)
        {
            case 1f: 
                egg1.SetActive(true); break;
            case 2f:
                egg1.SetActive(true);
                egg2.SetActive(true);break;
            case 3f:
                egg1.SetActive(true);
                egg2.SetActive(true);
                egg3.SetActive(true); break;
        }
    }
}
