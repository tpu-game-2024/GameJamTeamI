using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] PlayerHP HPSlider;

    [SerializeField]float speed = 3.0f;

    int hp = 100;

    GameObject catchableGO = null;
    GameObject catchingGO = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Wキー（前方移動）
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += speed * transform.forward * Time.deltaTime;
        }

        // Sキー（後方移動）
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= speed * transform.forward * Time.deltaTime;
        }

        // Dキー（右移動）
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += speed * transform.right * Time.deltaTime;
        }

        // Aキー（左移動）
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= speed * transform.right * Time.deltaTime;
        }

        if(catchableGO != null)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                catchingGO = catchableGO;
                catchableGO.transform.SetParent(this.gameObject.transform);
            }
        }

        if (catchingGO != null)
        {
            catchingGO.transform.localPosition = new Vector3(0, 0f, 1);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            hp -= 5;

            if (HPSlider != null)
            {
                HPSlider.SetValue(hp);
//            Debug.Log("接触によるダメージ");
            }
        }
    }

    public void Catchable(GameObject col)
    {
        catchableGO = col;
    }
}
