using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyStateBehavior : MonoBehaviour
{
    Rigidbody rb;
    int state = 0;
    Vector3 lastPos;
    float height;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        height = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == 2) {// îÚÇÒÇ≈ÇÈ
            // Ç†Ç‹ÇËìÆÇ©Ç»ÇØÇÍÇŒAIêßå‰Ç…ñﬂÇÈ
            if(Math.Abs(height - transform.position.y) < 0.1f) {
                state = 0;
                transform.position = new Vector3(transform.position.x, height, transform.position.z);
                rb.isKinematic = true;
                UnityEngine.Debug.Log("ñﬂÇ¡ÇΩ");
            }
        }

        lastPos = transform.position;
    }

    public void Catch()
    {
        if (state == 0)
        {
            state = 1;
        }
    }

        public void Throw(Vector3 dir)
    {
        if (state == 1)
        {
            state = 2;
            rb.isKinematic = false;
            Vector3 v = 0.4f * dir.normalized + 0.5f * Vector3.up;
            rb.AddForce(v * 1000.0f);
            UnityEngine.Debug.Log("comes");
        }
    }

    // ãììÆÇÃAIÇ∆ÇÃÇ‚ÇËéÊÇË
    public bool canMove()
    {
        return state == 0;
    }
}
