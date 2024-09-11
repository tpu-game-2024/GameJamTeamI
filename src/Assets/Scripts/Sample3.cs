using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample3 : MonoBehaviour
{
    //GameObject�^��ϐ�target�Ő錾���܂��B
    public GameObject target;
    float jumpForce = 4f;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.transform.position - transform.position;
        direction.y = 0;  // Y���̉�]�𖳎����Đ����ʂł̉�]�ɂ���

        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime);


    }
    void OnCollisionEnter(Collision col)
    {
        
        if (col.gameObject.tag == "Ground")
        {
            rb.velocity = Vector3.up * jumpForce;
            Vector3 p = new Vector3(0f, 0f, 0.001f);
            transform.Translate(p);
        }
    }
}