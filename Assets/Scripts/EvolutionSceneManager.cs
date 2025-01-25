using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EvolutionSceneManager : MonoBehaviour
{
    [SerializeField] public Sprite FirePrefab;
    [SerializeField] public Sprite WaterPrefab;
    [SerializeField] public Sprite ToxicPrefab;
    [SerializeField] public Sprite IcePrefab;
    [SerializeField] public Sprite NightPrefab;
    [SerializeField] public Sprite IdlePrefab;
    [SerializeField] private Image playerpng;
    [SerializeField] private TextMeshProUGUI FireText;
    [SerializeField] private TextMeshProUGUI WaterText;
    [SerializeField] private TextMeshProUGUI ToxicText;
    [SerializeField] private TextMeshProUGUI IceText;
    [SerializeField] private TextMeshProUGUI NightText;
    [SerializeField] private TextMeshProUGUI AdnText;

    private void Update()
    {
        
        AsignSprite(SpriteActual());
        AdnText.text = "Points Remaining: " + GameManager.instance.Adn.ToString();
        FireText.text = EvolutionManager.instance.FireEvolution.ToString();
        WaterText.text = EvolutionManager.instance.WaterEvolution.ToString();
        ToxicText.text = EvolutionManager.instance.ToxicEvolution.ToString();
        IceText.text = EvolutionManager.instance.IceEvolution.ToString();
        NightText.text = EvolutionManager.instance.nightEvolution.ToString();
    }
    public void AsignSprite(int evolucion)
    {
        switch (evolucion)
        {
            case 1:
                playerpng.sprite = FirePrefab;
                break;
            case 2:
                playerpng.sprite = WaterPrefab;
                break;
            case 3:
                playerpng.sprite = ToxicPrefab;
                break;
            case 4:
                playerpng.sprite = IcePrefab;
                break;
            case 5:
                playerpng.sprite = NightPrefab;
                break;
            case 6:
                playerpng.sprite = IdlePrefab;
                break;


        }
    }
    public int SpriteActual()
    {
        int[] valores = {EvolutionManager.instance.FireEvolution,
            EvolutionManager.instance.WaterEvolution,
            EvolutionManager.instance.ToxicEvolution,
            EvolutionManager.instance.IceEvolution,
            EvolutionManager.instance.nightEvolution};
        int maximo = 0;
        int prefab = 0;
        bool empate = false;
        for (int i = 0; i < valores.Length; i++)
        {
            if (valores[i] > maximo)
            {
                maximo = valores[i];
                prefab = i;
                empate = false;
            }
            else if (valores[i] == maximo && maximo > 0)
            {
                empate = true;
            }
        }
        return empate ? 6 : prefab + 1;
    }
    public void LevelUpHot()
    {
        if(GameManager.instance.Adn > 0)
        {
            EvolutionManager.instance.FireEvolution++;
            GameManager.instance.Adn--;
        }
    }
    public void LevelDownHot()
    {
        if (EvolutionManager.instance.FireEvolution > 0)
        {
            EvolutionManager.instance.FireEvolution--;
            GameManager.instance.Adn++;
        }
    }
    public void LevelUpCold()
    {
        if (GameManager.instance.Adn > 0)
        {
            EvolutionManager.instance.IceEvolution++;
        }
    }
    public void LevelDownCold()
    {
        if (EvolutionManager.instance.IceEvolution > 0)
        {
            EvolutionManager.instance.IceEvolution--;
            GameManager.instance.Adn++;
        }
    }

    public void LevelUpWater()
    {
        if (GameManager.instance.Adn > 0)
        {
            EvolutionManager.instance.WaterEvolution++;
            GameManager.instance.Adn--;
        }
    }
    public void LevelDownWater()
    {
        if (EvolutionManager.instance.WaterEvolution > 0)
        {
            EvolutionManager.instance.WaterEvolution--;
            GameManager.instance.Adn++;
        }
    }
    public void LevelUpToxic()
    {
        if (GameManager.instance.Adn > 0)
        {
            EvolutionManager.instance.ToxicEvolution++;
            GameManager.instance.Adn--;
        }
    }
    public void LevelDownToxic()
    {
        if(EvolutionManager.instance.ToxicEvolution > 0)
        {
            EvolutionManager.instance.ToxicEvolution--;
            GameManager.instance.Adn++;
        }
    }
    public void LevelUpDarkness()
    {
        if (GameManager.instance.Adn > 0)
        {
            EvolutionManager.instance.nightEvolution++;
            GameManager.instance.Adn--;
        }
    }
    public void LevelDownDarkness()
    {
        if (EvolutionManager.instance.nightEvolution > 0)
        {
            EvolutionManager.instance.nightEvolution--;
            GameManager.instance.Adn++;
        }
    }
}
