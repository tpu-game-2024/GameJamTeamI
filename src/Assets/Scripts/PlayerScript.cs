using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] PlayerHP HPSlider;

    [SerializeField]float speed = 3.0f;

    int hp = 1000;

    GameObject catchableGO = null;
    GameObject catchingGO = null;

    // Start is called before the first frame update
    void Start()
    {
        HPSlider.SetMaxValue(hp);
    }

    // Update is called once per frame
    void Update()
    {
#if false
        // W�L�[�i�O���ړ��j
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += speed * transform.forward * Time.deltaTime;
        }

        // S�L�[�i����ړ��j
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= speed * transform.forward * Time.deltaTime;
        }

        // D�L�[�i�E�ړ��j
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += speed * transform.right * Time.deltaTime;
        }

        // A�L�[�i���ړ��j
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= speed * transform.right * Time.deltaTime;
        }
#endif

        if (catchableGO != null)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                catchingGO = catchableGO;
                catchableGO.transform.SetParent(this.gameObject.transform);
            }
        }

        if (catchingGO != null)
        {
            catchingGO.transform.localPosition = new Vector3(0f, 1f, 1f);
                hp -= 1;

                if (HPSlider != null)
                {
                    HPSlider.SetValue(hp);
                    // UnityEngine.Debug.Log("�����Ă��鎞�̃_���[�W");
                }
        }
    }

    void OnControllerColliderHit(ControllerColliderHit col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            hp -= 5;

            if (HPSlider != null)
            {
                HPSlider.SetValue(hp);
//                UnityEngine.Debug.Log("�ڐG�ɂ��_���[�W");
            }
        }
    }


    public void Catchable(GameObject col)
    {
        catchableGO = col;
    }
}
