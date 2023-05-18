using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weather : MonoBehaviour
{
    [SerializeField] private Slider rainSlider;
    [SerializeField] private Slider windSlider;

    [SerializeField] private AudioSource windSound;
    [SerializeField] private DigitalRuby.RainMaker.BaseRainScript rainScript;

    private void Start()
    {   
        rainSlider.value = 0f;
        windSlider.value = 0f;

        rainSlider.onValueChanged.AddListener((v) => {
            rainScript.RainIntensity = v;
        });

        windSlider.onValueChanged.AddListener((v) => {
            windSound.volume = v;
        });
    
    }
}
