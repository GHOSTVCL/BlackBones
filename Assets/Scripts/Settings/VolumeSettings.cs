using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volumeAudio", 0.5f);
        AudioListener.volume = slider.value;

    }

    public void ChangeSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("volumeAudio", sliderValue);
        AudioListener.volume = slider.value;
    }
}
