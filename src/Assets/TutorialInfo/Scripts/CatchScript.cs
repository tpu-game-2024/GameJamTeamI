using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchScript : MonoBehaviour
{
    public bool Iscatch = false;
    [SerializeField, Tooltip("êe")]
    Transform parent = null;
    [SerializeField, Tooltip("éq")]
    Transform child = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("on hit");
        if (collision.gameObject.tag == "enemy")
        {
            Iscatch = true;
            Debug.Log(Iscatch);
            if (Input.GetKeyDown(KeyCode.C))
            {
                child.SetParent(parent);
                //child.transform.position = new Vector3(0, 0f, 1);
            }
            
        }
    }
    void OnCollisionExit(Collision collision)
    {
        Iscatch = false;
    }

}
