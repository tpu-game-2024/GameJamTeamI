using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] Slider HPSlider = default!;
    float value;
    float itaiCount = 0.0f;
    Vector3 initPosition;

    // Start is called before the first frame update
    void Start()
    {
        initPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        const float speed = 1;

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

        // 動かす
        itaiCount -= Time.deltaTime;
        if(0.0f < itaiCount)
        {
            Vector3 pos = initPosition + new Vector3(0f, 10.0f * (float)Math.Sin(100.0f * Time.time), 0f);
            transform.position = pos;
        }
        else
        {
            transform.position = initPosition;
        }
    }

    public void SetMaxValue(int v)
    {
        HPSlider.maxValue = v;
        value = v;
        HPSlider.value = v;
    }

    public void SetValue(int v)
    {
        value = v;
    }

    public void Itai()
    {
        itaiCount = 0.3f;
    }
}