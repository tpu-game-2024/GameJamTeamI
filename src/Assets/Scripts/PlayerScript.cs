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
        // 捕まえる
        if (Input.GetKey(KeyCode.C))
        {
            if(catchingGO == null)
            {
                // 捕まえていなければ捕まえる
                if (catchableGO != null)
                {
                    catchingGO = catchableGO;
                    catchingGO.transform.SetParent(this.gameObject.transform);
                }
            }
        }
        else if(catchingGO != null)
        {
            // 押していなくて敵を持っていれば投げる
            catchingGO.transform.SetParent(null);
            catchingGO = null;
        }

        // 捕まえている時はHPが下がる
        if (catchingGO != null)
        {
            catchingGO.transform.localPosition = new Vector3(0f, 1f, 1f);
            hp -= 1;

            if (HPSlider != null)
            {
                HPSlider.SetValue(hp);
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

    public int GetHP()
    {
        return hp;
    }
}
