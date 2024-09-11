using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class BossHP : MonoBehaviour
{
    [SerializeField] Slider BossHPSlider;
    [SerializeField] int hp = 1;
    private bool isColliding = false;

    // Start is called before the first frame update
    void Start()
    {
        BossHPSlider.maxValue = hp;
        BossHPSlider.value = hp; 
    }

    // Update is called once per frame
    void Update()
    { 
        
    }

        void OnCollisionEnter(Collision col)
    {
        if (isColliding) return;

        if (col.gameObject.tag == "Enemy")
        {
            hp -= 1;

            if (BossHPSlider != null)
            {
                BossHPSlider.value = hp;
            }

            isColliding = true;
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            isColliding = false;
        }
    }
}

