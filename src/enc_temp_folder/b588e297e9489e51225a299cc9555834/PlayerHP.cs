using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] Slider HPSlider = default!;
    float value;

    // Start is called before the first frame update
    void Start()
    {
        value = HPSlider.value;
    }

    // Update is called once per frame
    void Update()
    {
        const float speed = 0.1f;

        if (HPSlider.value < value - speed)
        {
            HPSlider.value += speed;
        }else if(HPSlider.value > value + speed)
        {
            HPSlider.value -= speed;
        }
        else
        {
            HPSlider.value = value;
        }
    }

    public void SetValue(int v)
    {
        value = v;
    }
}