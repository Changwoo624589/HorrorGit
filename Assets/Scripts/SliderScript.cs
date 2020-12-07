using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    private Slider slider;
    void Start()
    {
        slider = GetComponent<Slider>();
        PlayerData data = SaveSystem.LoadSettings();
        slider.value = data._mouseSensitivity;

       
    }

    void Update()
    {
        
    }
}
