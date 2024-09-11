using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample3 : MonoBehaviour
{
    //GameObjectå^ÇïœêîtargetÇ≈êÈåæÇµÇ‹Ç∑ÅB
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
        Quaternion lookRotation = Quaternion.LookRotation(target.transform.position - transform.position, Vector3.up);

        lookRotation.z = 0;
        lookRotation.x = 0;

        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 1f);
       
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