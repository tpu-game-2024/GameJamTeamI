using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample2 : MonoBehaviour
{
    //GameObject型を変数targetで宣言します。
    public GameObject target;
    EnemyStateBehavior enemyState;

    // Start is called before the first frame update
    void Start()
    {
        enemyState = GetComponent<EnemyStateBehavior>();// 汚くてごめんなさい
    }

    // Update is called once per frame
    void Update()
    {
        if (!enemyState.canMove()) { return; }// つかまっていたり飛んでいたり

        Quaternion lookRotation = Quaternion.LookRotation(target.transform.position - transform.position, Vector3.up);

        lookRotation.z = 0;
        lookRotation.x = 0;

        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 0.0005f);

        Vector3 p = new Vector3(0f, 0f, 0.005f);

        transform.Translate(p);
    }
}
