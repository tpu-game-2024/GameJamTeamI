using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentScript : MonoBehaviour
{
    public CatchScript catchscript;

    [SerializeField, Tooltip("親")]
    Transform parent = null;
    [SerializeField, Tooltip("子")]
    Transform child = null;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
//        if (catchscript.Iscatch == true && Input.GetKey(KeyCode.C))
//        {
//            child.SetParent(parent);
//        }
    }

}
