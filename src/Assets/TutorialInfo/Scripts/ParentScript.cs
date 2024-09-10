using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentScript : MonoBehaviour
{
    public CatchScript catchscript;

    [SerializeField, Tooltip("êe")]
    Transform parent = null;
    [SerializeField, Tooltip("éq")]
    Transform child = null;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (catchscript.Iscatch == true && Input.GetKey(KeyCode.C))
        {
            child.SetParent(parent);
        }
    }
}
