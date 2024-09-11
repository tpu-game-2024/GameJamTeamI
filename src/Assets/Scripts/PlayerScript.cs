using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] PlayerHP HPSlider;
    [SerializeField] int hp = 1000;

    GameObject catchableGO = null;// ���Ă�I�u�W�F�N�g
    GameObject catchingGO = null;// �����Ă���I�u�W�F�N�g

    // Start is called before the first frame update
    void Start()
    {
        HPSlider.SetMaxValue(hp);
    }

    // Update is called once per frame
    void Update()
    {
        // �ێ�����
        if (Input.GetKeyDown(KeyCode.C))
        {
            // �ێ����Ă��Ȃ���Γ�����
            if(catchingGO == null)
            {
                if (catchableGO != null)
                {
                    catchingGO = catchableGO;// �߂܂���
                    catchingGO.transform.SetParent(this.gameObject.transform);
                }
            }
            else
            {
                catchingGO.transform.localPosition = new Vector3(0f, 1f, 1f);
            }
        }
        else// �ێ����Ȃ�
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
