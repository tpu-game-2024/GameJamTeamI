using System.Collections;
using System.Collections.Generic;
//using System.Media;
using UnityEngine;

public class CatchScript : MonoBehaviour
{
    public bool IsCatch = false;

    [SerializeField, Tooltip("親")]
    Transform parent = null;
    [SerializeField, Tooltip("子")]
    Transform child = null;

    [SerializeField, Tooltip("player")] PlayerScript player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
//        Debug.Log("on hit");
        if (collision.gameObject.tag == "Enemy")
        {
            player.Catchable(collision.gameObject);

//            IsCatch = true;
//            Debug.Log(IsCatch);
//            if (Input.GetKeyDown(KeyCode.C))
//            {
//                child.SetParent(parent);
                //child.transform.position = new Vector3(0, 0f, 1);
//            }
            
        }
    }

    void OnCollisionExit(Collision collision)
    {
//        IsCatch = false;
        player.Catchable(null);
    }

}
