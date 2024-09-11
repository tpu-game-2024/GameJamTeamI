using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample3 : MonoBehaviour
{
    //GameObjectŒ^‚ğ•Ï”target‚ÅéŒ¾‚µ‚Ü‚·B
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
        direction.y = 0;  // Y²‚Ì‰ñ“]‚ğ–³‹‚µ‚Ä…•½–Ê‚Å‚Ì‰ñ“]‚É‚·‚é

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