using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public Slider HPSlider;
    // Start is called before the first frame update
    void Start()
    {
        HPSlider.value = 100;
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Enemy"){
            HPSlider.value -= 5;
            Debug.Log("�ڐG�ɂ��_���[�W");
        }

    }
    // Update is called once per frame
    void Update()
    {

    }
}