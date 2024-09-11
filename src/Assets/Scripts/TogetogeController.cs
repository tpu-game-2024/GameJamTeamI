using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogetogeController : MonoBehaviour
{
    //GameObjectå^ÇïœêîtargetÇ≈êÈåæÇµÇ‹Ç∑ÅB
    public GameObject target;
    [SerializeField] int hp = 3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Quaternion lookRotation = Quaternion.LookRotation(target.transform.position - transform.position, Vector3.up);

        lookRotation.z = 0;
        lookRotation.x = 0;

        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 1f);

        Vector3 p = new Vector3(0f, 0f, 0.001f);

        transform.Translate(p);
    }
    void OnControllerColliderHit(ControllerColliderHit col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            hp -= 1;
            if (hp < 0)
            {

            }

        }
    }
}
